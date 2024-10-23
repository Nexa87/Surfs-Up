using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using SurfsUpv3.Models;

using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SurfsUpv3.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Display a list of all bookings
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7137/api/Booking");

            if (response.IsSuccessStatusCode)
            {
                var bookingsJson = await response.Content.ReadAsStringAsync();
                var bookings = JsonConvert.DeserializeObject<List<Booking>>(bookingsJson);

                return View(bookings);
            }

            return View("Error");
        }

        // Display a single booking for editing
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7137/api/Booking/{id}");

            if (response.IsSuccessStatusCode)
            {
                var bookingJson = await response.Content.ReadAsStringAsync();
                var booking = JsonSerializer.Deserialize<Booking>(bookingJson);

                return View(booking);
            }

            return View("Error");
        }

        // Update a booking after admin edits
        [HttpPost]
        public async Task<IActionResult> Edit(Booking booking)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync($"https://localhost:7137/api/Booking/{booking.BookingId}", booking);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // Delete a booking
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7137/api/Booking/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }
    }
}
