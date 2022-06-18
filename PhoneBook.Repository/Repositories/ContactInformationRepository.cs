using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Repository.Repositories
{
    public class ContactInformationRepository : BaseRepository<ContactInformation>
    {
        private readonly DatabaseContext _context;

        public ContactInformationRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ContactInformation> GetContactInformationWithTypeAsync(int contactInformationId)
        {
            return await _context.ContactInformations.Where(c => c.UUID == contactInformationId)
                .Include(c => c.InformationType)
                .Include(c => c.Contact)
                .SingleOrDefaultAsync();
        }
    }
}
