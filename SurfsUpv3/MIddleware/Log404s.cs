namespace SurfsUpv3.Middleware
{
    public class Log404Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Log404Middleware> _logger;
        private static int _notfoundcount = 0;

        public Log404Middleware(RequestDelegate next, ILogger<Log404Middleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Call the next middleware in the pipeline
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                _notfoundcount++;
                _logger.LogInformation("404 Not Found encountered for {Path}", context.Request.Path);
            }

            // Log the request count and not found count
            _logger.LogInformation($"404 requests: {_notfoundcount}");
        }
    }

    // This permits us to do a 'app.UseHowManyHowMany();' in Program.cs :D
    public static class UseLog404sExtensions
    {
        public static IApplicationBuilder UseLog404s(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Log404Middleware>();
        }
    }
}
