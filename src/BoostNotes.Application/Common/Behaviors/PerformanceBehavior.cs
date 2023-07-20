using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

namespace BoostNotes.Application.Common.Behaviors
{
    internal class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<TRequest> _logger;
        private readonly Stopwatch _stopwatch;

        public PerformanceBehavior(
            ILogger<TRequest> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            _stopwatch.Start();
            var response = await next();
            _stopwatch.Stop();

            long ellapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

            if (ellapsedMilliseconds <= 500)
            {
                return response;
            }

            string requestName = typeof(TRequest).Name;

            _logger.LogInformation("Long Running Request: {Name} ({EllapsedMilliseconds} ms) {@Request}",
                requestName,
                ellapsedMilliseconds,
                request);

            return response;
        }
    }
}