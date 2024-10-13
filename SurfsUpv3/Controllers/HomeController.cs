using Microsoft.AspNetCore.Mvc;
using SurfsUpv3.Models;
using System.Diagnostics;

namespace SurfsUpv3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;

            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
           if(ModelState.IsValid) {

                return View();
            }
            else
            {
                return BadRequest("Failed to get weather data from the WeatherApp WebAPI.");
            }
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
