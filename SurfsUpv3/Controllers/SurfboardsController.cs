using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurfsUpv3.Models;
using System.Net.Http;

public class SurfboardsController : Controller
{
        private readonly IHttpClientFactory _httpClientFactory;

    public SurfboardsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7137/api/Surfboards"); // URL til dit Web API

        if (response.IsSuccessStatusCode)
        {
            // Læs JSON responsen som en string
            var jsonString = await response.Content.ReadAsStringAsync();

            // Konverter JSON til en liste af Product objekter
            var surfboards = JsonConvert.DeserializeObject<List<Surfboard>>(jsonString);

            // Sender data til dit view
            return View(surfboards);
        }
        else
        {
            // Returner en tom liste, hvis intet produkt hentes
            return View(new List<Surfboard>());
        }
    }
}