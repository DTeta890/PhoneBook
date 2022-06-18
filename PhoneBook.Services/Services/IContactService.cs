using PhoneBook.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContactsAsync();

        Task<Contact> GetContactWithContactInformationsAsync(int contactId);

        Task<Contact> GetContactAsync(int contactId);

        Task AddContactAsync(Contact contact);

        Task UpdateContactAsync(Contact contact);

        Task DeleteContactAsync(int contactId);
    }
}
