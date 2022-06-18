using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PhoneBook.Repository
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        private static readonly string DataConnectionString = new DatabaseConfiguration().GetDataConnectionString();
        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseNpgsql(DataConnectionString);

            return new DatabaseContext(builder.Options);
        }
    }
}
