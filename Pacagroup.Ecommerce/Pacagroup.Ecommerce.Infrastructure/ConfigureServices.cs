using MailKit.Net.Smtp;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Pacagroup.Ecommerce.Application.Interface.Infrastructure;
using Pacagroup.Ecommerce.Infrastructure.EventBus;
using Pacagroup.Ecommerce.Infrastructure.EventBus.Options;
using Pacagroup.Ecommerce.Infrastructure.Notification;
using Pacagroup.Ecommerce.Infrastructure.Notification.Options;

namespace Pacagroup.Ecommerce.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
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
        
        /* Servicio Mail*/
        services.ConfigureOptions<SendEmailOptionsSetup>();
        services.Configure<SendEmailOptions>(configuration.GetSection("SendEmailOptions"));
        services.AddScoped<INotification, NotificationSendMail>();
        services.AddScoped<ISmtpClient, SmtpClient>(provider =>
        {
            return new SmtpClient
            {
                // Configura aquí si es necesario, por ejemplo:
                // ServerCertificateValidationCallback = (s, c, h, e) => true
            };
        });


        return services;
    }
}