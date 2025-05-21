using OpenTelemetry.Trace;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Instrumentation
{
    public static class InstrumentationExtensions
    {
        public static IServiceCollection AddInstrumentation(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddOpenTelemetry()
            .WithTracing(tracerProviderBuilder =>
            {
                tracerProviderBuilder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()                    
                    .AddOtlpExporter(options =>
                    {
                        options.Endpoint = new Uri(configuration["OTEL_EXPORTER_OTLP_ENDPOINT"] ?? "http://otel-collector:4317");
                    });
            });

            return services;
        }
    }
}
