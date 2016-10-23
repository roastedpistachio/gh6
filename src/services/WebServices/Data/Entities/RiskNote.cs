using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Data.Entities
{
    public class RiskNote
    {
        public int Id { get; set; }
        public int RiskId { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }

        public IncomingRiskFactor IncomingRiskFactor { get; set; }
    }
}