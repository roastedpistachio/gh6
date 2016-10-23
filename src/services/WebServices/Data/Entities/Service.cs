using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Data.Entities
{
    public class Service
    {
        public int ServicesID { get; set; }
        public int ProjectEntryID { get; set; }
        public int PersonalID { get; set; }
        public DateTime DateProvided { get; set; }
        public int RecordType { get; set; }
        public int TypeProvided { get; set; }
        public int? OtherTypeProvided { get; set; }
        public int? SubTypeProvided { get; set; }
        public decimal? FAAmount { get; set; }
        public string ReferralOutcome { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Client Client { get; set; }
    }
}