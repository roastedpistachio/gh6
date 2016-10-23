using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Data.Entities
{
    public class IncomeBenefit
    {
        public int IncomeBenefitsID { get; set; }
        public int ProjectEntryID { get; set; }
        public int PersonalID { get; set; }
        public DateTime InformationDate { get; set; }
        public bool? IncomeFromAnySource { get; set; }
        public decimal? TotalMonthlyIncome { get; set; }
        public bool? Earned { get; set; }
        public decimal? EarnedAmount { get; set; }
        public bool? Unemployment { get; set; }
        public decimal? UnemploymentAmount { get; set; }
        public bool? SSI { get; set; }
        public decimal? SSIAmount { get; set; }
        public bool? SSDI { get; set; }
        public decimal? SSDIAmount { get; set; }
        public bool? VADisabilityService { get; set; }
        public decimal? VADisabilityServiceAmount { get; set; }
        public bool? VADisabilityNonService { get; set; }
        public decimal? VADisabilityNoServiceAmount { get; set; }
        public bool? PrivateDisability { get; set; }
        public decimal? PrivateDisabilityAmount { get; set; }
        public bool? WorkersComp { get; set; }
        public decimal? WorkersCompAmount { get; set; }
        public bool? TANF { get; set; }
        public decimal? TANFAmount { get; set; }
        public bool? GA { get; set; }
        public decimal? GAAmount { get; set; }
        public bool? SocSecRetirement { get; set; }
        public decimal? SocSecRetirementAmount { get; set; }
        public bool? Pension { get; set; }
        public decimal? PensionAmount { get; set; }
        public bool? ChildSupport { get; set; }
        public decimal? ChildSupportAmount { get; set; }
        public bool? Alimony { get; set; }
        public decimal? AlimonyAmount { get; set; }
        public bool? OtherIncomeSource { get; set; }
        public decimal? OtherIncomeAmount { get; set; }
        public string OtherIncomeSourceIdentify { get; set; }
        public bool? BenefitsFromAnySource { get; set; }
        public bool? SNAP { get; set; }
        public bool? WIC { get; set; }
        public bool? TANFChildCare { get; set; }
        public bool? TANFTransportation { get; set; }
        public bool? OtherTANF { get; set; }
        public bool? RentalAssistanceOngoing { get; set; }
        public bool? RentalAssistanceTemp { get; set; }
        public bool? OtherBenefitsSource { get; set; }
        public string OtherBenefitsSourceIdentify { get; set; }
        public bool? InsuranceFromAnySource { get; set; }
        public bool? Medicaid { get; set; }
        public string NoMedicaidReason { get; set; }
        public bool? Medicare { get; set; }
        public string NoMedicareReason { get; set; }
        public bool? SCHIP { get; set; }
        public string NoSCHIPReason { get; set; }
        public bool? VAMedicalServices { get; set; }
        public string NoVAMedReason { get; set; }
        public bool? EmployerProvided { get; set; }
        public string NoEmployerProvidedReason { get; set; }
        public int? COBRA { get; set; }
        public string NoCOBRAReason { get; set; }
        public bool? PrivatePay { get; set; }
        public string NoPrivatePayReason { get; set; }
        public bool? StateHealthIns { get; set; }
        public string NoStateHealthInsReason { get; set; }
        public bool? HIVAIDSAssistance { get; set; }
        public string HIVAIDSAssistanceReason { get; set; }
        public bool? ADAP { get; set; }
        public string NoADAPReason { get; set; }
        public int? DataCollectionStage { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Client Client { get; set; }
    }
}