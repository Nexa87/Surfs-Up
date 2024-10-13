using Microsoft.Extensions.DependencyInjection;

namespace SurfsUpWebAPI.Middleware
{
    public class HowManyAPIRequest
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HowManyAPIRequest> _logger;
        private static int _requestCount = 0;
        private readonly IServiceScopeFactory _scopeFactory;

        public HowManyAPIRequest (RequestDelegate next, ILogger<HowManyAPIRequest> logger, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            // Increment our counter, for the current running session
            _requestCount++;

            // Create a scope to resolve scoped services
            using (var scope = _scopeFactory.CreateScope ()) {
                var loggingService = scope.ServiceProvider.GetRequiredService<ILoggingService> ();

                // Log the API call using the logging service
                await loggingService.LogApiCallAsync (context.Request.Path);
            }

            // Call the next middleware in the pipeline
            await _next (context);

            // Log the request count
            _logger.LogInformation ("API has been called {RequestCount} times. [{TimeStamp}]", _requestCount, DateTime.Now);
        }
    }

    // This permits us to do a 'app.UseHowManyAPIRequests();' in Program.cs
    public static class HowManyAPIRequestExtensions
    {
        public static IApplicationBuilder UseHowManyAPIRequests (this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HowManyAPIRequest> ();
        }
    }
}
