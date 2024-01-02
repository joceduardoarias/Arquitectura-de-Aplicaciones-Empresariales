using MassTransit;
using Microsoft.Extensions.Hosting;
using Pacagroup.Ecommerce.ConsoleApp.Consumer;

public class Program
{
    public static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddMassTransit(x =>
                {
                    x.AddConsumer<DiscountCreatedConsumer>();
                    x.UsingRabbitMq((context, configuration) =>
                    {

                        configuration.Host("localhost", "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });

                        configuration.ConfigureEndpoints(context);
                    });
                });
            })
            .Build()
            .RunAsync();

    }
}