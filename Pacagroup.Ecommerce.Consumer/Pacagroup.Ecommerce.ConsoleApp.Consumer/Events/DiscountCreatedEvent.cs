using Pacagroup.Ecommerce.Domain.Enums;

namespace Pacagroup.Ecommerce.Domain.Events; // Warning - Debe tener el mismo namespace que en el proyecto del productor 

public class DiscountCreatedEvent // Warning - Esta clase debe ser igual a la que se declara en el pproyecto del productor
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Percent { get; set; }
    public DiscountStatus Status { get; set; }
}
/*Los Warnings anteriormente agregado hace referencia a la implementación del patrón producer - consumer cuando utilizamos el paquete MassTransit 
  Nota: Buscar otras implementaciones del MessageBroker RabbitMQ   
 */