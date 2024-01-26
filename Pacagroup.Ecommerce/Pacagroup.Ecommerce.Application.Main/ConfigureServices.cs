using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Interface.UseCase;
using Pacagroup.Ecommerce.Application.UseCase.Categories;
using Pacagroup.Ecommerce.Application.UseCase.Common.Behaviours;
using Pacagroup.Ecommerce.Application.UseCase.Customers;
using Pacagroup.Ecommerce.Application.UseCase.Discounts;
using Pacagroup.Ecommerce.Application.UseCase.Users;
using Pacagroup.Ecommerce.Application.Validator;
using System.Reflection;

namespace Pacagroup.Ecommerce.Application.UseCase
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); //Registrando el servicio MediatR
                cfg.AddBehavior(typeof(IPipelineBehavior<,>),typeof(LoggingBehaviour<,>)); //Registrando el LoggingBehaviour en MediatR
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); //En tiempo de ejecución descubre la clases que se van a mapear.
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            services.AddScoped<IDiscountsApplication, DiscountsApplication>();

            services.AddTransient<UserDtoValidator>();
            services.AddTransient<DiscountDotValidator>();

            return services;
        }
    }
}
