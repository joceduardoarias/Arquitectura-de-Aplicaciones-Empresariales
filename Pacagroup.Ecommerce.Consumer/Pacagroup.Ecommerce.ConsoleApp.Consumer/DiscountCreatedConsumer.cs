using MassTransit;
using Pacagroup.Ecommerce.Domain.Events;
using System.Text.Json;

namespace Pacagroup.Ecommerce.ConsoleApp.Consumer;

public class DiscountCreatedConsumer : IConsumer<DiscountCreatedEvent>
{

    public async Task Consume(ConsumeContext<DiscountCreatedEvent> context)
    {
        var jsonMessage = JsonSerializer.Serialize(context.Message);
        await Console.Out.WriteLineAsync($"Message form producer : {jsonMessage}");
    }
}
