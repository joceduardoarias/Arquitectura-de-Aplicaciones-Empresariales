using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

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
            
            //Esta configuración sirve para ver en las respuestas los valores enum con su respresentación en string
            services.AddMvc();
            
            services.AddControllers().AddJsonOptions(options =>
            {
                var enumConverter = new JsonStringEnumConverter();
                options.JsonSerializerOptions.Converters.Add(enumConverter);
            });

            return services;
        }
    }
}
