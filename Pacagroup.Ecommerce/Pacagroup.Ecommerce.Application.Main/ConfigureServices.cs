using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Interface.UseCase;
using Pacagroup.Ecommerce.Application.UseCase.Categories;
using Pacagroup.Ecommerce.Application.UseCase.Customers;
using Pacagroup.Ecommerce.Application.UseCase.Users;

namespace Pacagroup.Ecommerce.Application.UseCase
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            
            return services;
        }
    }
}
