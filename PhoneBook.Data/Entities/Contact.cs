using System.Collections.Generic;

namespace PhoneBook.Data.Entities
{
    public class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public virtual IEnumerable<ContactInformation> ContactInformations { get; set; }
    }
}
