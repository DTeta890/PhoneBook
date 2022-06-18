using Microsoft.Extensions.Configuration;

namespace PhoneBook.Repository
{
    public class DatabaseConfiguration : ConfigurationBase
    {
        private const string DataConnectionKey = "PhoneBookDatabase";

        public string GetDataConnectionString()
        {
            return GetConfiguration().GetConnectionString(DataConnectionKey);
        }
    }
}
