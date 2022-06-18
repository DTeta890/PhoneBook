using PhoneBook.Data.Entities;
using PhoneBook.Repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Services
{
    public class ContactInformationService : IContactInformationService
    {
        private readonly ContactInformationRepository _context;

        public ContactInformationService(ContactInformationRepository context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactInformation>> GetContactInformationsAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<ContactInformation> GetContactInformationWithTypeAsync(int contactInformationId)
        {
            return await _context.GetContactInformationWithTypeAsync(contactInformationId);
        }

        public async Task<ContactInformation> GetContactInformationAsync(int contactInformationId)
        {
            return await _context.GetAsync(contactInformationId);
        }

        public async Task AddContactInformationAsync(ContactInformation contactInformation)
        {
            await _context.AddAsync(contactInformation);
        }

        public async Task UpdateContactInformationAsync(ContactInformation contactInformation)
        {
            await _context.UpdateAsync(contactInformation);
        }

        public async Task DeleteContactInformationAsync(int contactInformationId)
        {
            await _context.RemoveAsync(contactInformationId);
        }
    }
}
