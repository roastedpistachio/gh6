using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Data.Entities
{
    public class Client
    {
        public int UUID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int NameDataQuality { get; set; }
        public int? SocialSecurityNumber { get; set; }
        public int SocialSecurityNumberDataQuality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int DateOfBirthDataQuality { get; set; }
        public bool AmIndAKNative { get; set; }
        public bool Asian { get; set; }
        public bool Black { get; set; }
        public bool NativeHIOtherPacific { get; set; }
        public bool White { get; set; }
        public bool RaceNone { get; set; }
        public int? Gender { get; set; }
        public bool OtherGender { get; set; }
        public bool? VeterenStatus { get; set; }
        public int? YearEnteredService { get; set; }
        public int? YearSeparated { get; set; }
        public bool WorldWarII { get; set; }
        public bool KoreanWar { get; set; }
        public bool VietnamWar { get; set; }
        public bool DesertStorm { get; set; }
        public bool AfghanistanOEF { get; set; }
        public bool IraqOND { get; set; }
        public bool OtherTheater { get; set; }
        public int? MilitaryBranch { get; set; }
        public int? DischargeStatus { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<Disabilitie> Disabilities { get; set; }
        public virtual ICollection<EmploymentEducation> EmploymentEducations { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Exit> Exits { get; set; }
        public virtual ICollection<HealthAndDV> HealthAndDvs { get; set; }
        public virtual ICollection<IncomeBenefit> IncomeBenefits { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}