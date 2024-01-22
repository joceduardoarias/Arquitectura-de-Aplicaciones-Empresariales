using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Pacagroup.Ecommerce.Infrastructure.Notification.Options;

public class SendEmailOptionsSetup : IConfigureOptions<SendEmailOptions>
{
    private const string ConfigurationSectionName = "EmailConfig";
    private readonly IConfiguration _configuration;

    public SendEmailOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(SendEmailOptions options)
    {
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}
