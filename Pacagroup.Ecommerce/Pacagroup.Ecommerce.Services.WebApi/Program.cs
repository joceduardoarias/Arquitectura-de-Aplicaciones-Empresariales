using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Feature;
using Pacagroup.Ecommerce.Services.WebApi.Modules.HealthCheck;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Injection;
using Pacagroup.Ecommerce.Services.WebApi.Modules.RateLimiterExtensions;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Redis;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger;
using Pacagroup.Ecommerce.Persistence;
using Pacagroup.Ecommerce.Application.UseCase;
using Pacagroup.Ecommerce.Infrastructure;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Middleware;
using Pacagroup.Ecommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Servicios para creación de aplicaciones Web API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Cors policy
builder.Services.AddFeatures(builder.Configuration);
// Configure Persistence services
builder.Services.AddPersistenceServices(builder.Configuration);
// Configure Application services
builder.Services.AddApplicationServices(builder.Configuration);
// Configure Dependency Injection            
builder.Services.AddInjection(builder.Configuration);
// Configure JWT Authentication
builder.Services.AddAuthentication(builder.Configuration);
// Register the swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwagger();
// Configure HealthCheck
//builder.Services.AddHealthCheck(builder.Configuration);

// Register Redis
builder.Services.AddRedisCache(builder.Configuration);
// Register RabbitMQ, Mail Srevice
builder.Services.AddInfrastructureServices(builder.Configuration);
// Register RateLimit
builder.Services.AddRateLimiting(builder.Configuration);
// Register the API versioning services
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
    options.SubstitutionFormat = "VVV";
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var db = services.GetRequiredService<ApplicationDbContext>();
            db.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Error applying migrations");
            throw; // o registrar y continuar si no querés detener la app
        }
    }
}



// Configure the http request pipelne

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // build a swagger endpoint for each discover API version

        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
    app.UseReDoc(options =>
    {
        options.DocumentTitle = "Pacagruop Tencnology services API Market";
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SpecUrl = $"/swagger/{description.GroupName}/swagger.json";
        }
    });
}

app.UseHttpsRedirection();
app.UseCors("_myAllowSpecificOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.MapControllers();
app.MapHealthChecks("/health");

app.AddMiddleware();

app.Run();