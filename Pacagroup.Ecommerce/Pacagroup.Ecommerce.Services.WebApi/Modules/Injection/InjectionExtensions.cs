using Pacagroup.Ecommerce.Application.Interface.UseCase;
using Pacagroup.Ecommerce.Application.UseCase;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Transversal.Logging;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration) {
            
            services.AddSingleton<IConfiguration>(configuration);                                    
            services.AddScoped(typeof(IloggerApp<>), typeof(LoggerAdapter<>));            
                        
            return services;
        }
    }
}
