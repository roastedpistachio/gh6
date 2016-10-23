using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebServices.Data;
using WebServices.Data.Entities;
using WebServices.Models;

namespace WebServices.Controllers
{
    [RoutePrefix("risk")]
    public class RiskController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> List()
        {
            var response = default(IHttpActionResult);

            try
            {
                using (var context = new ClientDataContext())
                {
                    var query = await GetRiskQuery(context).ToListAsync();

                    var results = (from risk in query
                                   where !string.IsNullOrWhiteSpace(risk.FirstName) &&
                                         !risk.FirstName.Contains(" V ")
                                   select GetRiskResponse(risk)).ToList();

                    response = Ok(results);
                }
            }
            catch (Exception ex)
            {
                response = InternalServerError(ex);
            }

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var response = default(IHttpActionResult);

            try
            {
                using (var context = new ClientDataContext())
                {
                    var query = GetRiskQuery(context);
                    var risks = await query.ToListAsync();
                    var risk = risks.FirstOrDefault(r => r.Id == id);

                    if (risk == null)
                    {
                        response = NotFound();
                    }
                    else
                    {
                        response = Ok(GetRiskResponse(risk));
                    }
                }
            }
            catch(Exception ex)
            {
                response = InternalServerError(ex);
            }

            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> PutUpdate([FromUri]int id, [FromBody]RiskDto riskDto)
        {
            var response = default(IHttpActionResult);

            try
            {
                using (var context = new ClientDataContext())
                {
                    var risk = context.IncomingRiskFactors.FirstOrDefault(r => r.Id == id);

                    if (risk == null)
                    {
                        response = NotFound();
                    }
                    else
                    {
                        risk.UpdatedDate = DateTime.Now;
                        risk.RiskRating = riskDto.Risk;
                        risk.RiskType = riskDto.RiskFactor;
                        risk.CaseStatus = riskDto.CaseStatus;
                        risk.FirstName = riskDto.Client?.FirstName;
                        risk.LastName = riskDto.Client?.LastName;
                        risk.YearOfBirth = riskDto.Client?.DateOfBirth?.Year;
                        risk.Address = riskDto.Client?.Address?.Address;
                        risk.City = riskDto.Client?.Address?.City;
                        risk.State = riskDto.Client?.Address?.State;

                        await context.SaveChangesAsync();

                        response = Ok();
                    }
                }
            }
            catch(Exception ex)
            {
                response = InternalServerError(ex);
            }

            return response;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> PostRisk([FromBody]RiskDto riskDto)
        {
            var response = default(IHttpActionResult);

            try
            {
                var risk = new IncomingRiskFactor()
                {
                    CaseStatus = riskDto.CaseStatus,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    FirstName = riskDto.Client?.FirstName,
                    LastName = riskDto.Client?.LastName,
                    RiskRating = riskDto.Risk,
                    RiskType = riskDto.RiskFactor,
                    YearOfBirth = riskDto.Client?.DateOfBirth?.Year,
                    Address = riskDto.Client?.Address?.Address,
                    City = riskDto?.Client?.Address?.City,
                    State = riskDto?.Client?.Address?.State
                };

                using (var context = new ClientDataContext())
                {
                    context.IncomingRiskFactors.Add(risk);
                    await context.SaveChangesAsync();
                }

                response = Ok();
            }
            catch(Exception ex)
            {
                response = InternalServerError(ex);
            }

            return response;
        }

        [HttpPost]
        [Route("incoming-risk")]
        public async Task<IHttpActionResult> Import([FromBody]IncomingRiskFactor incomingRiskFactor)
        {
            var response = default(IHttpActionResult);

            try
            {
                using (var context = new ClientDataContext())
                {
                    incomingRiskFactor.CreatedDate = DateTime.Now;
                    incomingRiskFactor.UpdatedDate = DateTime.Now;
                    incomingRiskFactor.CaseStatus = "Assignment";
                    context.IncomingRiskFactors.Add(incomingRiskFactor);
                    await context.SaveChangesAsync();
                }

                response = Ok();
            }
            catch (Exception ex)
            {
                response = InternalServerError(ex);
            }

            return response;
        }

        [HttpPost]
        [Route("import")]
        public async Task<IHttpActionResult> Import([FromBody]MappingMetadata mappingMetadata)
        {
            var response = default(IHttpActionResult);

            try
            {
                var file = await ImportContainer.GetFileAsync(mappingMetadata.FileName);
                var csv = CsvParser.Parse(file);
                var inserts = new List<IncomingRiskFactor>();
                var properties = TypeDescriptor.GetProperties(typeof(IncomingRiskFactor)).OfType<PropertyDescriptor>();

                foreach (var row in csv.Data.Select(d => d.ToList()))
                {
                    var incomingRiskFactor = new IncomingRiskFactor()
                    {
                        RiskType = mappingMetadata.RiskType,
                        CaseStatus = "Assignment",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    };

                    foreach (var mapping in mappingMetadata.Mappings)
                    {
                        var property = properties.FirstOrDefault(p => p.Name == mapping.Key);
                        var value = row[mapping.Value];

                        if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(incomingRiskFactor, value);
                        }
                    }

                    inserts.Add(incomingRiskFactor);
                }

                using (var context = new ClientDataContext())
                {
                    context.IncomingRiskFactors.AddRange(inserts);
                    await context.SaveChangesAsync();
                }

                response = Ok();
            }
            catch (Exception ex)
            {
                response = InternalServerError(ex);
            }

            return response;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IHttpActionResult> Upload()
        {
            var response = default(IHttpActionResult);

            try
            {
                var file = await GetFileFromRequestAsync(Request);

                if (file != null)
                {
                    var fileName = Guid.NewGuid().ToString("N");
                    var fileContent = await file.ReadAsByteArrayAsync();
                    var csv = CsvParser.Parse(fileContent, hasHeaderRow: true);

                    await ImportContainer.AddFileAsync(fileName, fileContent);

                    response = Ok(new
                    {
                        FileName = fileName,
                        Headers = csv.Headers,
                        Data = csv.Data.FirstOrDefault()
                    });
                }
            }
            catch (Exception ex)
            {
                response = InternalServerError(ex);
            }

            return response;
        }

        private async Task<HttpContent> GetFileFromRequestAsync(HttpRequestMessage request)
        {
            var provider = new MultipartMemoryStreamProvider();
            await request.Content.ReadAsMultipartAsync(provider);

            // Expect one file for now
            return provider.Contents.FirstOrDefault();
        }

        private IQueryable<IncomingRiskFactor> GetRiskQuery(ClientDataContext context)
        {
            return context.IncomingRiskFactors
                    .Include(i => i.CaseWorker)
                    .DefaultIfEmpty()
                    .Include(i => i.RiskNotes)
                    .AsQueryable();
        }

        private object GetRiskResponse(IncomingRiskFactor risk)
        {
            return new
            {
                id = risk.Id,
                created = risk.CreatedDate,
                risk = risk.RiskRating ?? 5,
                riskFactor = risk.RiskType,
                caseWorker = "Cody Nutt",
                caseStatus = risk.CaseStatus,
                caseOverview = risk.CaseOverview,
                client = new
                {
                    name = $"{risk.FirstName} {risk.LastName}",
                    address = new
                    {
                        address = risk.Address,
                        city = risk.City,
                        state = risk.State
                    }
                },
                initialContact = new
                {
                    contacted = risk.Contacted,
                    informationObtained = risk.InformationObtained,
                    helpRequired = risk.HelpRequired
                },
                mitigation = new { },
                followUp = new { },
                notes = (from note in risk.RiskNotes
                         select new
                         {
                             date = note.CreatedDate,
                             author = note.Author,
                             message = note.Message
                         })
            };
        }
    }
}