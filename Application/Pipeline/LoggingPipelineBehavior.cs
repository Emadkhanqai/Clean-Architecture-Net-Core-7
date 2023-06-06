using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Pipeline
{
    public class LoggingPipelineBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest, IRequest<TResponse>
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Currently handling request: {Request}", typeof(TRequest).Name);

            var response = await next();

            _logger.LogInformation("Currently handling response: {Response}", typeof(TResponse).Name);

            return response;

        }
    }
}
