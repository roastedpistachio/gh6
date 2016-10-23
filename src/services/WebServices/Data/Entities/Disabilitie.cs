using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Data.Entities
{
    public class Disabilitie
    {
        public string DisabilitiesID { get; set; }
        public int ProjectEntryID { get; set; }
        public int PersonalID { get; set; }
        public DateTime InformationDate { get; set; }
        public int DisabilityType { get; set; }
        public int DisabilityResponse { get; set; }
        public int? IndefiniteAndImpairs { get; set; }
        public bool? DocumentationOnFile { get; set; }
        public bool? ReceivingServices { get; set; }
        public bool? PATHHowConfirmed { get; set; }
        public bool? PATHSMIInformation { get; set; }
        public bool? TCellCountAvailable { get; set; }
        public int? TCellCount { get; set; }
        public string TCellSource { get; set; }
        public bool? ViralLoadAvailable { get; set; }
        public string ViralLoad { get; set; }
        public string ViralLoadSource { get; set; }
        public int? DataCollectionStage { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdateBy { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Client Client { get; set; }
    }
}