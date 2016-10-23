using System;

namespace WebServices.Models
{
    public class ClientSearchParameters
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? YearOfBirth { get; set; }

        public string FirstName =>
            string.IsNullOrWhiteSpace(Name) ? null : Name.Split(' ')[0];

        public string LastName =>
            string.IsNullOrWhiteSpace(Name) ? null :
                Name.Split(' ').Length > 1 ? Name.Split(' ')[1] : null;
    }
}