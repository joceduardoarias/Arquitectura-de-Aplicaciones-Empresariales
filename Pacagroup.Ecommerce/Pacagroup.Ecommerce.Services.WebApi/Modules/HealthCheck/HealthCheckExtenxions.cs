using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.HealthCheck
{
    public static class HealthCheckExtenxions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] {"database"});
            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;    
        }
    }
}
