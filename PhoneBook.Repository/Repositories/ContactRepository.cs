using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Repository.Repositories
{
    public class ContactRepository : BaseRepository<Contact>
    {
        private readonly DatabaseContext _context;

        public ContactRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Contact> GetContactWithContactInformationsAsync(int contactId)
        {
            return await _context.Contacts.Where(c => c.UUID == contactId)
                .Include(c => c.ContactInformations)
                .ThenInclude(c => c.InformationType)
                .SingleOrDefaultAsync();
        }
    }
}
