using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Pacagroup.Ecommerce.Application.Interface.Infrastructure;
using Pacagroup.Ecommerce.Infrastructure.Notification.Options;

namespace Pacagroup.Ecommerce.Infrastructure.Notification;

public class NotificationSendMail : INotification
{   
    private readonly ILogger<NotificationSendMail> _logger;
    private readonly IOptions<SendEmailOptions> _sendEmailOptions;
    private readonly ISmtpClient  _smtpClient;
    public NotificationSendMail(ILogger<NotificationSendMail> logger, IOptions<SendEmailOptions> sendEmailOptions, ISmtpClient smtpClient)
    {
        _logger = logger;
        _sendEmailOptions = sendEmailOptions;
        _smtpClient = smtpClient;
    }

    public async Task<bool> SendMailAsync(string subject, string body, CancellationToken cancellationToken = default)
    {
        try
        {
            MimeMessage message = BuildMessage(subject, body);

            await _smtpClient.ConnectAsync(_sendEmailOptions.Value.Host, int.Parse(_sendEmailOptions.Value.Port), MailKit.Security.SecureSocketOptions.StartTls, cancellationToken);
            await _smtpClient.AuthenticateAsync(_sendEmailOptions.Value.UserName, _sendEmailOptions.Value.Password, cancellationToken);
            await _smtpClient.SendAsync(message, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al enviar el correo electrónico");
            return false;
        }
        finally
        {
            await _smtpClient.DisconnectAsync(true, cancellationToken);
        }
    }

    private MimeMessage BuildMessage(string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(MailboxAddress.Parse(_sendEmailOptions.Value.FromAddress));
        message.To.Add(MailboxAddress.Parse(_sendEmailOptions.Value.ToAddress));
        message.Subject = subject;
        message.Body = new TextPart(TextFormat.Html) { Text = body };

        return message;
    }

}
