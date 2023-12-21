using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Persistence.Context;
using Pacagroup.Ecommerce.Persistence.Repositories;

namespace Pacagroup.Ecommerce.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped<ICustomersRepository, CustomerRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            return services;
        }
    }
}