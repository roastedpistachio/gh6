using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Data.Entities
{
    public class Exit
    {
        public int ExitID { get; set; }
        public int ProjectEntryID { get; set; }
        public int PersonalID { get; set; }
        public DateTime ExitDate { get; set; }
        public int? Destination { get; set; }
        public string OtherDestination { get; set; }
        public string AssessmentDisposition { get; set; }
        public string OtherDisposition { get; set; }
        public int? HouseAssessment { get; set; }
        public int? SubsidyInformation { get; set; }
        public bool? ConnectionWithSOAR { get; set; }
        public bool? WrittenAftercarePlan { get; set; }
        public bool? AssistanceMainstreamBenefits { get; set; }
        public bool? PermanentHousePlacement { get; set; }
        public bool? TemporaryShelterPlacement { get; set; }
        public bool? ExitCounseling { get; set; }
        public bool? FurtherFollowUpServices { get; set; }
        public bool? ScheduledFollowUpContacts { get; set; }
        public bool? ResourcePackage { get; set; }
        public bool? OtherAftercarePlanOrAction { get; set; }
        public int? ProjectCompletionStatus { get; set; }
        public int? EarlyExitReason { get; set; }
        public bool? FamilyReunificationAchieved { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Client Client { get; set; }
    }
}