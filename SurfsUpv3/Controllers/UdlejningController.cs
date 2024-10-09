using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurfsUpv3.Models;
using System.Net.Http;

namespace SurfsUpWebApp.Controllers
{
    public class UdlejningController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UdlejningController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7137/api/Surfboards"); // URL til dit Web API

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var surfboards = JsonConvert.DeserializeObject<List<Surfboard>>(jsonString);

                    return View(surfboards);
                }
                else
                {
                    // Returner en tom liste, hvis API-kaldet fejler
                    return View(new List<Surfboard>());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl under API-kald: {ex.Message}");
                return View(new List<Surfboard>()); // Returner tom liste, hvis der opstår en fejl
            }
        }
    }
}
