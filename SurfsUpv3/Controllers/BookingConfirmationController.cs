using Microsoft.AspNetCore.Mvc;

using SurfsUpv3.Models;

using System.Text.Json;


namespace SurfsUpv3.Controllers
{
    public class BookingConfirmationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingConfirmationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidationTest(Booking model)
        {
            if (ModelState.IsValid)
            {

                if (model.WetsuitId != null)
                {
                    // Ensure gender and size are also set
                    if (model.Gender == null || model.Size == null)
                    {
                        ModelState.AddModelError("", "Du skal vælge både køn og størrelse, hvis du vil leje en våddragt.");
                        return View(model);
                    }
                }
                var priceOptions = new Dictionary<int, int>
                {
                    { 1, 299 },
                    { 3, 599 },
                    { 24, 799 },
                    { 72, 999 },
                    { 168, 1299 }
                };

                // Find den valgte pris
                if (priceOptions.TryGetValue(model.Price, out var selectedPrice))
                {
                    model.Price = selectedPrice;
                }
                else
                {
                    model.Price = -1; // Value indicating "Something-Went-Wrong"
                }
                model.BookingTime = DateTime.Now;    

                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7137/api/Booking", model);

                if (response.IsSuccessStatusCode)
                {
                    // Læs svaret som en streng
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("API Response: " + jsonResponse);

                    // Deserialiser svaret fra API'et
                    var bookingResponse = await response.Content.ReadFromJsonAsync<Booking>();

                    // Log bookingResponse for at se, hvad den indeholder
                    if (bookingResponse != null)
                    {
                        Console.WriteLine("Booking ID from response: " + bookingResponse.BookingId);

                        // Opdatér model med booking ID'et fra API'et
                        model.BookingId = bookingResponse.BookingId;

                        // Send modellen videre til bekræftelsessiden
                        return View("~/Views/BookingConfirmation/Index.cshtml", model);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Noget gik galt. Kunne ikke hente bookingdetaljer.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Noget gik galt, prøv igen.");
                }
            }

            return View("~/Views/RentOrder/Index.cshtml", model);
        }
    }
}
