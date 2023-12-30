using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Pacagroup.Ecommerce.Application.Interface.Infrastructure;
using Pacagroup.Ecommerce.Infrastructure.EventBus;
using Pacagroup.Ecommerce.Infrastructure.EventBus.Options;

namespace Pacagroup.Ecommerce.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.ConfigureOptions<RabbitMqOptionsSetup>();
        services.AddScoped<IEventBus, EventBusRabbitMQ>();
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, configuration) =>
            {
                RabbitMqOptions? options = services.BuildServiceProvider()
                .GetRequiredService<IOptions<RabbitMqOptions>>()
                .Value;

                configuration.Host(options.HostName, options.VirtualHost, h =>
                {
                    h.Username(options.UserName);
                    h.Password(options.Password);
                });

                configuration.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}