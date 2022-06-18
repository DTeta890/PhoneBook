using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Repository;
using PhoneBook.Repository.Repositories;
using PhoneBook.Services.Services;

namespace PhoneBook.Web
{
    public static class ConfigureContainerExtensions
    {
        public static void AddDbContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(new DatabaseConfiguration().GetDataConnectionString()));
        }

        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ContactRepository, ContactRepository>();
            serviceCollection.AddScoped<ContactInformationRepository, ContactInformationRepository>();
            serviceCollection.AddScoped<InformationTypeRepository, InformationTypeRepository>();
        }

        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IContactService, ContactService>();
            serviceCollection.AddTransient<IContactInformationService, ContactInformationService>();
            serviceCollection.AddTransient<IInformationTypeService, InformationTypeService>();
        }
    }
}
