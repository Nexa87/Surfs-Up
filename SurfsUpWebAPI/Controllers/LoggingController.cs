using Microsoft.AspNetCore.Mvc;
using SurfsUpWebAPI.Data;
using SurfsUpWebAPI.Middleware;
using SurfsUpWebAPI.Models;

namespace SurfsUpWebAPI.Controllers
{
    [ApiController]
    [Route("/logging")]
    public class LoggingController
    {
        private readonly SurfsUpAPIContext _context;
        private readonly ILogger<LoggingController> _logger;

        public LoggingController (SurfsUpAPIContext context, ILogger<LoggingController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost ("log404")]
        public async Task Log404 ()
        {
            _logger.LogInformation ($"{DateTime.Now} | Log404() in LoggingController called.");
            if (_context != null) {
                SiteLog sl = new SiteLog ("404");
                await _context.SiteLogs.AddAsync (sl);
                await _context.SaveChangesAsync ();
            }
        }

        [HttpPost ("logapicall")]
        public async Task LogAPICall ()
        {
            _logger.LogInformation ($"{DateTime.Now} | LogAPICall() in LoggingController called.");
            if (_context != null) {
                SiteLog sl = new SiteLog ("API Call");
                await _context.SiteLogs.AddAsync (sl);
                await _context.SaveChangesAsync ();
            }
        }
    }
}
