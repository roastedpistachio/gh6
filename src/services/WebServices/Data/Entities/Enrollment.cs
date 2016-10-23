using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Data.Entities
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int ProjectEntryID { get; set; }
        public int PersonalID { get; set; }
        public int ProjectID { get; set; }
        public DateTime EntryDate { get; set; }
        public int HouseholdID { get; set; }
        public int RelationshipToHoH { get; set; }
        public int? ResidencePrior { get; set; }
        public string OtherResidencePrior { get; set; }
        public int? ResidencePriorLengthOfStay { get; set; }
        public bool? DisablingCondition { get; set; }
        public bool? EntryFromStreetESSH { get; set; }
        public DateTime? DateToStreetESSH { get; set; }
        public int? TimesHomelessPastThreeYears { get; set; }
        public int? MonthsHomelessPastThreeYears { get; set; }
        public int? HousingStatus { get; set; }
        public DateTime? DateOfEngagement { get; set; }
        public bool? InPermanentHousing { get; set; }
        public DateTime? ResidentialMoveInDate { get; set; }
        public DateTime? DateOfPATHStatus { get; set; }
        public bool? ClientEnrolledinPATH { get; set; }
        public string ReasonNotEnrolled { get; set; }
        public string WorstHousingSituation { get; set; }
        public int? PercentAMI { get; set; }
        public string LastPermanentStreet { get; set; }
        public string LastPermanentCity { get; set; }
        public string LastPermanentState { get; set; }
        public int? LastPermanentZip { get; set; }
        public int? AddressDataQuality { get; set; }
        public DateTime? DateOfBCPStatus { get; set; }
        public bool? FYSBYouth { get; set; }
        public string ReasonNoServices { get; set; }
        public string SexualOrientation { get; set; }
        public bool? FormerWardChildWelfare { get; set; }
        public int? ChildWelfareYears { get; set; }
        public int? ChildWelfareMonths { get; set; }
        public string FormerWardJuvenileJustice { get; set; }
        public int? JuvenileJusticeYears { get; set; }
        public int? JuvenileJusticeMonths { get; set; }
        public string HouseholdDynamics { get; set; }
        public int? SexualOrientationGenderIDYouth { get; set; }
        public int? SexualOrientationGenderIDFam { get; set; }
        public bool? HousingIssuesYouth { get; set; }
        public bool? HousingIssuesFam { get; set; }
        public bool? SchoolEducationalIssuesYouth { get; set; }
        public bool? SchoolEducationalIssuesFam { get; set; }
        public bool? UnemploymentYouth { get; set; }
        public bool? UnemploymentFam { get; set; }
        public bool? MentalHealthIssuesYouth { get; set; }
        public bool? MentalHealthIssuesFam { get; set; }
        public bool? HealthIssuesYouth { get; set; }
        public bool? HealthIssuesFam { get; set; }
        public bool? PhysicalDisabilityYouth { get; set; }
        public bool? PhysicalDisabilityFam { get; set; }
        public bool? MentalDisabilityYouth { get; set; }
        public bool? MentalDisabilityFam { get; set; }
        public bool? AbuseAndNeglectYouth { get; set; }
        public bool? AbuseAndNeglectFam { get; set; }
        public bool? AlcoholDrugAbuseYouth { get; set; }
        public bool? AlcoholDrugAbuseFam { get; set; }
        public bool? InsufficientIncome { get; set; }
        public bool? ActiveMilitaryParent { get; set; }
        public bool? IncarceratedParent { get; set; }
        public int? IncarceratedParentStatus { get; set; }
        public string ReferralSource { get; set; }
        public int? CountOutreachReferralApproaches { get; set; }
        public bool? ExchangeForSex { get; set; }
        public bool? ExchangeForSexPastThreeMonths { get; set; }
        public int? CountOfExchangeForSex { get; set; }
        public bool? AskedOrForcedToExchangeForSex { get; set; }
        public bool? AskedOrForcedToExchangeForSexPastThreeMonths { get; set; }
        public bool? WorkPlaceViolenceThreats { get; set; }
        public bool? WorkplacePromiseDifference { get; set; }
        public bool? CoercedToContinueWork { get; set; }
        public bool? LaborExploitPastThreeMonths { get; set; }
        public int? HPScreeningScore { get; set; }
        public int? VAMCStation { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Client Client { get; set; }
    }
}