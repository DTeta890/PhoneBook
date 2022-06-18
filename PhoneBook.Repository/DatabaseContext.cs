using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<InformationType> InformationTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Contact>()
                .HasMany(c => c.ContactInformations)
                .WithOne(c => c.Contact)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ContactInformation>()
                .HasOne(c => c.InformationType);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChanges, CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.ApplyAuditInformation();
            return await base.SaveChangesAsync(acceptAllChanges, cancellationToken);
        }
    }
}
