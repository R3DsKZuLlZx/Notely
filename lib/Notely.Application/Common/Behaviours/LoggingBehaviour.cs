using MediatR;
using Microsoft.Extensions.Logging;

namespace Notely.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest, TResponse>(ILogger<TRequest> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Logged request {@Request}", request);
        var response = await next();
        logger.LogInformation("Logged response {@Response}", response);

        return response;
    }
}
