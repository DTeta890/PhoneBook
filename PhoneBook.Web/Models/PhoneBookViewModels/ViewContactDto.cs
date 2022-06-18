using PhoneBook.Data.Entities;
using System.Collections.Generic;

namespace PhoneBook.Web.Models.PhoneBookViewModels
{
    public class ViewContactDto
    {
        public int UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public IEnumerable<ContactInformation> ContactInformations { get; set; }
    }
}
