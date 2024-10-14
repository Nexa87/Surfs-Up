using SurfsUpWebAPI.Data;
using SurfsUpWebAPI.Models;

namespace SurfsUpWebAPI.Middleware
{
    // Services/ILoggingService.cs
    public interface ILoggingService
    {
        Task LogApiCallAsync (string path);
    }

    // Services/LoggingService.cs
    public class LoggingService : ILoggingService
    {
        private readonly SurfsUpAPIContext _context;

        public LoggingService (SurfsUpAPIContext context)
        {
            _context = context;
        }

        public async Task LogApiCallAsync (string path)
        {
            SiteLog logEntry = new SiteLog ($"API Call to {path}");
            await _context.SiteLogs.AddAsync (logEntry);
            await _context.SaveChangesAsync ();
        }
    }

}
