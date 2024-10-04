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
            // If it's a 404, tally that too
            if (context.Response.StatusCode == 404)
                _notfoundcount += 1;

            // Increment the request count
            _requestCount++;

            // Log the request count
            _logger.LogInformation("API has been called {RequestCount} times.", _requestCount);
            _logger.LogInformation($"404 requests: {_notfoundcount}");

            // TODO Poke these info into the DB for future reference ?

            // Call the next middleware in the pipeline
            await _next(context);
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
