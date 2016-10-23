using System;

namespace WebServices.Data.Entities
{
    public class CourtCase
    {
        public int Id { get; set; }
        public string CaseNumber { get; set; }
        public DateTime Date { get; set; }
        public string InvolvedParties { get; set; }
        public string CaseType { get; set; }
        public bool Processed { get; set; }
    }
}