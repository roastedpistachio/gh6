using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Data.Entities
{
    public class EmploymentEducation
    {
        public int EmploymentEducationID { get; set; }
        public int ProjectEntryID { get; set; }
        public int PersonalID { get; set; }
        public DateTime InformationDate { get; set; }
        public string LastGradeCompleted { get; set; }
        public int? SchoolStatus { get; set; }
        public int Employed { get; set; }
        public int? EmploymentType { get; set; }
        public string NotEmployedReason { get; set; }
        public int DataCollectionStage { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Client Client { get; set; }
    }
}