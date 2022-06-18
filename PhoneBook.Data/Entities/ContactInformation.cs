using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Data.Entities
{
    public class ContactInformation : BaseEntity
    {
        public string Content { get; set; }
        public int ContactId { get; set; }
        public int InformationTypeId { get; set; }

        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }
        [ForeignKey("InformationTypeId")]
        public virtual InformationType InformationType { get; set; }
    }
}
