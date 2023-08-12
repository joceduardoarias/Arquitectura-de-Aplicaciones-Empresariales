using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger
{
    public static class SwaggerExtensiones
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            // Register the swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Service API Market",
                    Description = "A simple example ASP.NET Core web API",
                    Version = "v1"
                });
                // Set the comments path for the swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                var securityScheme = new OpenApiSecurityScheme()
                {
                    Name = "Authoritation",
                    Description = "Enter JWT Bearer tonken **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference()
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }

                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {securityScheme, new List<string>() { } }
                });
            });
            return services;
        }
    }
}
