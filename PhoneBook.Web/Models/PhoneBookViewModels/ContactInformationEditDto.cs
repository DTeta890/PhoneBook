using PhoneBook.Data.Entities;
using System.Collections.Generic;

namespace PhoneBook.Web.Models.PhoneBookViewModels
{
    public class ContactInformationEditDto
    {
        public int UUID { get; set; }
        public string Content { get; set; }
        public int InformationTypeId { get; set; }
        public IEnumerable<InformationType> InformationTypes { get; set; }
    }
}
