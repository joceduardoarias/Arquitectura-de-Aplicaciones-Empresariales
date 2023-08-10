
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Validator;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this  IServiceCollection services)
        {
            services.AddMvc(options => { }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UsersDtoValidator>());
            return services;
        }
    }
}
