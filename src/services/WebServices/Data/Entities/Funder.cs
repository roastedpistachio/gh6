using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Data.Entities
{
    public class Funder
    {
        public int FunderID { get; set; }
        public int ProjectID { get; set; }
        public int FunderOther { get; set; }
        public int? GrandID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}