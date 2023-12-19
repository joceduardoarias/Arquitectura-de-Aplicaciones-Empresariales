using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Interface.UseCase;
using Pacagroup.Ecommerce.Application.UseCase;
using Pacagroup.Ecommerce.Persistence.Data;
using Pacagroup.Ecommerce.Persistence.Repository;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Transversal.Logging;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration) {
            
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomersRepository, CustomerRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped(typeof(IloggerApp<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            return services;
        }
    }
}
