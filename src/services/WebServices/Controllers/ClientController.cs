using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebServices.Data;
using WebServices.Models;

namespace WebServices.Controllers
{
    [RoutePrefix("client")]
    public class ClientController : ApiController
    {
        [HttpGet]
        [Route("search")]
        public async Task<IHttpActionResult> SearchAsync([FromUri]ClientSearchParameters searchParameters)
        {
            var response = default(IHttpActionResult);

            try
            {
                using (var context = new ClientDataContext())
                {
                    var query = context.Clients.Include("Enrollments").AsQueryable();

                    if(!string.IsNullOrWhiteSpace(searchParameters.FirstName))
                    {
                        query = query.Where(c => c.FirstName == searchParameters.FirstName);
                    }
                    
                    if(!string.IsNullOrWhiteSpace(searchParameters.LastName))
                    {
                        query = query.Where(c => c.LastName == searchParameters.LastName);
                    }

                    if(!string.IsNullOrWhiteSpace(searchParameters.Address))
                    {
                        query = query.Where(c => 
                            c.Enrollments.Any(e => 
                                e.LastPermanentStreet == searchParameters.Address || e.LastPermanentStreet.StartsWith(searchParameters.Address)));
                    }

                    if(!string.IsNullOrWhiteSpace(searchParameters.City))
                    {
                        query = query.Where(c => c.Enrollments.Any(e => e.LastPermanentCity == searchParameters.City));
                    }

                    if(!string.IsNullOrWhiteSpace(searchParameters.State))
                    {
                        query = query.Where(c => c.Enrollments.Any(e => e.LastPermanentState == searchParameters.State));
                    }

                    if(searchParameters.YearOfBirth.HasValue)
                    {
                        query = query.Where(c => c.DateOfBirth.Value.Year == searchParameters.YearOfBirth);
                    }

                    var queryResult = (from client in await query.ToListAsync()
                                       let enrollment = client.Enrollments.FirstOrDefault()
                                       orderby client.FirstName, client.LastName
                                       select new
                                       {
                                           id = client.UUID,
                                           firstName = client.FirstName,
                                           lastName = client.LastName,
                                           address = enrollment?.LastPermanentStreet,
                                           city = enrollment?.LastPermanentCity,
                                           state = enrollment?.LastPermanentState,
                                           dateOfBirth = client.DateOfBirth
                                       }).ToList().Take(10);

                    response = Ok(queryResult);
                }
            }
            catch(Exception ex)
            {
                response = InternalServerError(ex);
            }

            return response;
        }
    }
}