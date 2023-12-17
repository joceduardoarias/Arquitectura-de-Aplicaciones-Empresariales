using Microsoft.Extensions.Logging;
using Pacagroup.Ecommerce.Transversal.Common;
using WatchDog;

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
        WatchLogger.Log(message);//Log que se guarda en la base de datos
    }
    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message, args);
        WatchLogger.Log(message);
    }
    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
        WatchLogger.Log(message);
    }
}
