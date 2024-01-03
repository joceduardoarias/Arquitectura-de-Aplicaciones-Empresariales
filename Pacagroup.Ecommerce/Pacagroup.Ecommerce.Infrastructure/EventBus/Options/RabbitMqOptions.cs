namespace Pacagroup.Ecommerce.Infrastructure.EventBus.Options;

public class RabbitMqOptions
{
    public string HostName { get; init; } /* atributo de acceso init permite asignar un valor a la propiedad durante la creación del objeto
                                           y una vez inicializado es valor no puede cambiar.*/
    public string VirtualHost { get; init; }
    public string UserName { get; init; }
    public string Password { get; init; }
}
