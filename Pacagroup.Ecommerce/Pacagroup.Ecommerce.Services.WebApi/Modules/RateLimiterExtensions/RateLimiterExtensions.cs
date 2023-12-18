using Microsoft.AspNetCore.RateLimiting;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.RateLimiterExtensions;

public static class RateLimiterExtensions
{
    public static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration configuration) 
    {
        var fixedWindowPolicy = "fixedWindow";
        services.AddRateLimiter(options =>
        {
            options.AddFixedWindowLimiter(policyName: fixedWindowPolicy, fixedWindow =>
            {
                fixedWindow.PermitLimit = int.Parse(configuration["RateLimitinfg:PermitLimit"]);
                fixedWindow.Window = TimeSpan.FromSeconds(double.Parse(configuration["RateLimitinfg:Window"]));
                fixedWindow.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                fixedWindow.QueueLimit = int.Parse(configuration["RateLimitinfg:QueueLimit"]); ;
            });
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        });
        return services;
    }
}
