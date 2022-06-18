using PhoneBook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Services
{
    public interface IContactInformationService
    {
        Task<IEnumerable<ContactInformation>> GetContactInformationsAsync();

        Task<ContactInformation> GetContactInformationWithTypeAsync(int contactInformationId);

        Task<ContactInformation> GetContactInformationAsync(int contactInformationId);

        Task AddContactInformationAsync(ContactInformation contactInformation);

        Task UpdateContactInformationAsync(ContactInformation contactInformation);

        Task DeleteContactInformationAsync(int contactInformationId);
    }
}
