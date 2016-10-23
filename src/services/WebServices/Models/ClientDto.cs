using System;

namespace WebServices.Models
{
    public class ClientDto
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != null)
                {
                    _name = value.Trim().Replace("  ", " ");
                }
                else
                {
                    _name = null;
                }
                
            }
        }
        public DateTime? DateOfBirth { get; set; }
        public AddressDto Address { get; set; }

        public string FirstName =>
            string.IsNullOrWhiteSpace(Name) ? null : Name.Trim().Split(' ')[0];

        public string LastName =>
            string.IsNullOrWhiteSpace(Name) ? null :
                Name.Trim().Split(' ').Length > 1 ? Name.Trim().Split(' ')[1] : null;
    }
}