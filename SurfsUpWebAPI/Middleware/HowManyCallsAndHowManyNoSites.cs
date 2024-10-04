using System.Globalization;

namespace SurfsUpWebAPI.Middleware
{
    public class HowManyCallsAndHowManyNoSites
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HowManyCallsAndHowManyNoSites> _logger;
        private static int _requestCount = 0;
        private static int _notfoundcount = 0;

        public HowManyCallsAndHowManyNoSites(RequestDelegate next, ILogger<HowManyCallsAndHowManyNoSites> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Increment the request count
            _requestCount++;

            // Call the next middleware in the pipeline
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                //_notfoundcount++;
                _logger.LogInformation("404 Not Found encountered for {Path}", context.Request.Path);
            }

            // Log the request count and not found count
            _logger.LogInformation("API has been called {RequestCount} times.", _requestCount);
            _logger.LogInformation($"404 requests: {_notfoundcount}");
        }
    }

    // This permits us to do a 'app.UseHowManyHowMany();' in Program.cs :D
    public static class HowManyCallsAndHowManyNoSitesExtensions
    {
        public static IApplicationBuilder UseHowManyHowMany(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HowManyCallsAndHowManyNoSites>();
        }
    }

}
