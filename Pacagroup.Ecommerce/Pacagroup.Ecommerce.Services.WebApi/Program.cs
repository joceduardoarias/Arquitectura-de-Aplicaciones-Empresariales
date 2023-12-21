using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Feature;
using Pacagroup.Ecommerce.Services.WebApi.Modules.HealthCheck;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Injection;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Mapper;
using Pacagroup.Ecommerce.Services.WebApi.Modules.RateLimiterExtensions;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Redis;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Validator;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Watch;
using Pacagroup.Ecommerce.Persistence;
using Pacagroup.Ecommerce.Application.UseCase;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Servicios para creación de aplicaciones Web API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Auto Mapper Configurations
builder.Services.AddMapper();
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
// Configure Validators
builder.Services.AddValidator();
// Configure HealthCheck
builder.Services.AddHealthCheck(builder.Configuration);
// Register WatchDog
builder.Services.AddWatchDog(builder.Configuration);
// Register Redis
builder.Services.AddRedisCache(builder.Configuration);
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

// Configure the http request pipelne

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        // build a swagger endpoint for each discover API version
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });

}

app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseCors("_myAllowSpecificOrigins");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(_ => { });
app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseWatchDog(option =>
{
    option.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    option.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});

app.Run();