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

        public async Task<IActionResult> Index()
        {
            // Create an HttpClient instance
            var client = _httpClientFactory.CreateClient();

            // URL of the WeatherApp WebAPI's weather forecast endpoint
            var weatherApiUrl = "https://localhost:7137/bookings";

            // Send an HTTP GET request to the WeatherApp WebAPI
            var response = await client.GetAsync(weatherApiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string (or deserialize to an object if needed)
                var weatherData = await response.Content.ReadAsStringAsync();

                // You can pass this weather data to the view or process it further
                ViewData["DATA"] = weatherData;
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
