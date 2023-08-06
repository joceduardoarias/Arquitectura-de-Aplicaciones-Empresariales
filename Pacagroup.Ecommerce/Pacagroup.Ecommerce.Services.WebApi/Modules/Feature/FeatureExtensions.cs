using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        
        public static IServiceCollection AddFeatures(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "_myAllowSpecificOrigins";
            
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
          .AllowAnyHeader()
          .AllowAnyMethod()));

            return services;
        }
    }
}
