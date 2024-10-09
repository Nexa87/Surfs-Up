using Microsoft.AspNetCore.Mvc;
using SurfsUpv3.Models;

namespace SurfsUpWebApp.Controllers
{
    public class RentOrderController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public RentOrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return View(booking);  // Returnerer view med valideringsfejl
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7137/api/Booking", booking);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("BookingSuccess");  // Redirecter til en side, der bekræfter bookingen
            }

            ModelState.AddModelError(string.Empty, "Noget gik galt, prøv igen.");
            return View(booking);  // Returnerer view med fejl
        }

        public IActionResult Index(string? passedSurfboard)
        {
            var booking = new Booking(passedSurfboard);

            return View(booking); // NOTE : If we pass a string into View() in MVC, it thinks we're looking for a View with that string as its name | If we need to do this, do 'View(model: myString)'
        }
    }
}
