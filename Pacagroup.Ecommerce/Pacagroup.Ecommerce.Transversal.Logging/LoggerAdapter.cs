using Microsoft.Extensions.Logging;
using Pacagroup.Ecommerce.Transversal.Common;


namespace Pacagroup.Ecommerce.Transversal.Logging;

public class LoggerAdapter<T> : IloggerApp<T>
{
    private readonly ILogger<T> _logger;
    public LoggerAdapter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }
    public void LogError(string message, params object[] args)
    {
        _logger.LogError(message, args);        
    }
    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message, args);        
    }
    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);        
    }
}
