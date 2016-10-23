using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Data.Entities
{
    public class HealthAndDV
    {
        public int HealthAndDVID { get; set; }
        public int ProjectEntryID { get; set; }
        public int PersonalID { get; set; }
        public DateTime InformationDate { get; set; }
        public int DomesticViolenceVictim { get; set; }
        public int? WhenOccurred { get; set; }
        public bool? CurrentlyFleeing { get; set; }
        public int? GeneralHealthStatus { get; set; }
        public int? DentalHealthStatus { get; set; }
        public int? MentalHealthStatus { get; set; }
        public int? PregnancyStatus { get; set; }
        public DateTime? DueDate { get; set; }
        public int? DataCollectionStage { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Client Client { get; set; }
    }
}