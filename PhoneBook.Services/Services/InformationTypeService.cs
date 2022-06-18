using PhoneBook.Data.Entities;
using PhoneBook.Repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Services
{
    public class InformationTypeService : IInformationTypeService
    {
        private readonly InformationTypeRepository _context;

        public InformationTypeService(InformationTypeRepository context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InformationType>> GetInformationTypesAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<InformationType> GetInformationTypeAsync(int informationTypeId)
        {
            return await _context.GetAsync(informationTypeId);
        }

        public async Task AddInformationTypeAsync(InformationType informationType)
        {
            await _context.AddAsync(informationType);
        }

        public async Task UpdateInformationTypeAsync(InformationType informationType)
        {
            await _context.UpdateAsync(informationType);
        }

        public async Task DeleteInformationTypeAsync(int informationTypeId)
        {
            await _context.RemoveAsync(informationTypeId);
        }
    }
}
