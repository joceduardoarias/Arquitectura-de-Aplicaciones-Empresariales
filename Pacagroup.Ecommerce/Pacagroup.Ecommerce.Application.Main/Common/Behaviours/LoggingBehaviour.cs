using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Pacagroup.Ecommerce.Application.UseCase.Common.Behaviours;

public class LoggingBehaviour<TRequest, Tresponse> : IPipelineBehavior<TRequest, Tresponse> where TRequest : IRequest
{   
    private readonly ILogger<LoggingBehaviour<TRequest, Tresponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, Tresponse>> logger)
    {
        _logger = logger;
    }

    public async Task<Tresponse> Handle(TRequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Request Handling: {name} {@request}", typeof(TRequest).Name, JsonSerializer.Serialize(request));
        var response = await next();
        _logger.LogInformation("CleanArchitecture Response Handling: {name} {@response}", typeof(TRequest).Name, JsonSerializer.Serialize(response));

        return response;
    }
}
