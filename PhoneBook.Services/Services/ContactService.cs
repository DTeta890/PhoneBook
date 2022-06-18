using PhoneBook.Data.Entities;
using PhoneBook.Repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactRepository _context;

        public ContactService(ContactRepository context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<Contact> GetContactWithContactInformationsAsync(int contactId)
        {
            return await _context.GetContactWithContactInformationsAsync(contactId);
        }

        public async Task<Contact> GetContactAsync(int contactId)
        {
            return await _context.GetAsync(contactId);
        }

        public async Task AddContactAsync(Contact contact)
        {
            await _context.AddAsync(contact);
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            await _context.UpdateAsync(contact);
        }

        public async Task DeleteContactAsync(int contactId)
        {
            await _context.RemoveAsync(contactId);
        }
    }
}
