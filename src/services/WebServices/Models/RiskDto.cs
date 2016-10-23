using System;
using System.Collections.Generic;

namespace WebServices.Models
{
    public class RiskDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int Risk { get; set; }
        public string RiskFactor { get; set; }
        public string CaseWorker { get; set; }
        public string CaseStatus { get; set; }
        public string CaseOverview { get; set; }
        public ClientDto Client { get; set; }
        public IEnumerable<NoteDto> Notes { get; set; }
    }
}