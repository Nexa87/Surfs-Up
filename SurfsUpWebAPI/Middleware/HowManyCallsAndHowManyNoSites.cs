﻿using System.Globalization;

namespace SurfsUpWebAPI.Middleware
{
    public class HowManyAPIRequest
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HowManyAPIRequest> _logger;
        private static int _requestCount = 0;

        public HowManyAPIRequest(RequestDelegate next, ILogger<HowManyAPIRequest> logger)
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
                _logger.LogInformation("404 Not Found encountered for {Path}", context.Request.Path);
            }

            // Log the request count and not found count
            _logger.LogInformation("API has been called {RequestCount} times.", _requestCount);
        }
    }

    // This permits us to do a 'app.UseHowManyHowMany();' in Program.cs :D
    public static class HowManyAPIRequestExtensions
    {
        public static IApplicationBuilder UseHowManyAPIRequests(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HowManyAPIRequest>();
        }
    }

}
