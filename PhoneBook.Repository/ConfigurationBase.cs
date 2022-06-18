using Microsoft.Extensions.Configuration;
using System;

namespace PhoneBook.Repository
{
    public abstract class ConfigurationBase
    {
        protected IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("settings.json").Build();
        }
    }
}
