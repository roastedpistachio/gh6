using System;
using System.Collections.Generic;

namespace WebServices.Data.Entities
{
    public class IncomingRiskFactor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int? YearOfBirth { get; set; }
        public string Details { get; set; }
        public bool? Processed { get; set; }
        public string RiskType { get; set; }
        public int? RiskRating { get; set; }
        public int? CaseWorkerId { get; set; }
        public string CaseStatus { get; set; }
        public string CaseOverview { get; set; }
        public bool? Contacted { get; set; }
        public bool? InformationObtained { get; set; }
        public bool? HelpRequired { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual CaseWorker CaseWorker { get; set; }
        public virtual ICollection<RiskNote> RiskNotes { get; set; }
    }
}