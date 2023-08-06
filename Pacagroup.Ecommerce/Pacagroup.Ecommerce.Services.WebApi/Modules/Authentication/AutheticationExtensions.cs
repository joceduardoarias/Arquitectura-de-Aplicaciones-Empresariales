using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pacagroup.Ecommerce.Services.WebApi.Helpers;
using System;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication
{
    public static class AutheticationExtensions
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //Mapear la configuración de los valores de la sección config en el appSetting.json
            var appSettingsSection = configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = System.Text.Encoding.ASCII.GetBytes(appSettings.Secret);
            var Issuer = appSettings.Issuer;
            var Audience = appSettings.Audience;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(x =>
               {
                   x.Events = new JwtBearerEvents
                   {
                       OnTokenValidated = context =>
                       {
                           var userId = int.Parse(context.Principal.Identity.Name);
                           return Task.CompletedTask;
                       },

                       OnAuthenticationFailed = context =>
                       {
                           if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                           {
                               context.Response.Headers.Add("Token-Expired", "true");
                           }
                           return Task.CompletedTask;
                       }
                   };
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = false;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = true,
                       ValidIssuer = Issuer,
                       ValidateAudience = true,
                       ValidAudience = Audience,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.Zero
                   };
               });
            return services;
        }
    }
}
