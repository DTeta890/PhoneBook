using PhoneBook.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Services.Services
{
    public interface IInformationTypeService
    {
        Task<IEnumerable<InformationType>> GetInformationTypesAsync();

        Task<InformationType> GetInformationTypeAsync(int informationTypeId);

        Task AddInformationTypeAsync(InformationType informationType);

        Task UpdateInformationTypeAsync(InformationType informationType);

        Task DeleteInformationTypeAsync(int informationTypeId);
    }
}
