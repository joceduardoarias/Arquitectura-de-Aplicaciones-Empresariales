
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Validator;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this  IServiceCollection services)
        {
            //services.AddControllers(options => { }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>());
            services.AddValidatorsFromAssemblyContaining<UserDtoValidator>(); // register validators
            services.AddFluentValidationAutoValidation(); // the same old MVC pipeline behavior
            services.AddFluentValidationClientsideAdapters();
            return services;
        }
    }
}
