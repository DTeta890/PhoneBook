using PhoneBook.Data.Entities;

namespace PhoneBook.Repository.Repositories
{
    public class InformationTypeRepository : BaseRepository<InformationType>
    {
        private readonly DatabaseContext _context;

        public InformationTypeRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
