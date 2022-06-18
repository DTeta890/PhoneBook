using PhoneBook.Data.Entities;
using System.Collections.Generic;

namespace PhoneBook.Web.Models.PhoneBookViewModels
{
    public class ContactInformationCreateDto
    {
        public string Content { get; set; }
        public int ContactId { get; set; }
        public int InformationTypeId { get; set; }
        public IEnumerable<InformationType> InformationTypes { get; set; }
    }
}
