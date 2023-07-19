using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using MediatR.Pipeline;

namespace BoostNotes.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;

            _logger.LogInformation("Request: {@Request}",
                requestName,
                request);
        }
    }
}