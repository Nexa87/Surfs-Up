using System.Net.Http;

namespace SurfsUpv3.Middleware
{
    public class Log404Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Log404Middleware> _logger;
        private static int _notfoundcount = 0;

        private readonly IHttpClientFactory _httpClientFactory; // For notifying the API to track 404 requests & persist them

        public Log404Middleware(RequestDelegate next, ILogger<Log404Middleware> logger, IHttpClientFactory httpClientFactory)
        {
            _next = next;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Call the next middleware in the pipeline
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                _notfoundcount++;

                var result = await Notify_API_About_404 ();
                _logger.LogInformation (result.ToString());

                //_logger.LogInformation("404 Not Found encountered for {Path}", context.Request.Path);
            }

            // Log the request count and not found count
            _logger.LogInformation($"404 requests: {_notfoundcount}");
        }

        async Task<string> Notify_API_About_404 ()
        {
            // Create an HttpClient instance
            var client = _httpClientFactory.CreateClient ();

            // Send an HTTP GET request to the WeatherApp WebAPI
            var response = await client.PostAsync ("https://localhost:7137/Logging/log404", null);  // POST without body

            return $"API was attempted notified. \n{response.StatusCode}";
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
