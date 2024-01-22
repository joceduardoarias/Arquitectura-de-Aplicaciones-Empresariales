namespace Pacagroup.Ecommerce.Infrastructure.Notification.Options;

public class SendEmailOptions
{
    public string Host { get; set; } = string.Empty;
    public string Port { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;    
    public string Password { get; set; } = string.Empty;
    public string FromAddress { get; set; } = string.Empty;
    public string ToAddress { get; set; } = string.Empty;

}
