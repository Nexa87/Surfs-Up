using Microsoft.AspNetCore.Mvc;

using SurfsUpv3.Models;

namespace SurfsUpv3.Controllers
{
    public class BookingConfirmationController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        // For future reference, can have multiple of same, as long as they're overloaded (+ remember, by default they're Get, otherwise specify post, as here)
        // [HttpPost]
        //public IActionResult Index(Booking model)
        //{

        //}
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingConfirmationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        [HttpPost]
        public async Task<IActionResult> ValidationTest(Booking model)
        {

            if (ModelState.IsValid)
            {
                // Everything looks good, proceed Mr. Starwhisper

                // Indlæs priserne fra en kilde, hvis nødvendigt
                var priceOptions = new Dictionary<int, int>
                {
                    { 1, 299 },
                    { 3, 599 },
                    { 24, 799 },
                    { 72, 999 },
                    { 168, 1299 }
                };
                Console.WriteLine($"Selected Price: {model.RentHours}");


                // Find den valgte pris tekst

                if (priceOptions.TryGetValue(model.Price, out var selectedPrice)) /*skal nok laves som en post til db*/
                {
                    model.Price = selectedPrice;
                }
                else
                {
                    model.Price = -1; // Value indicating "Something-Went-Wrong"
                }


                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7137/api/Booking", model);

                if (response.IsSuccessStatusCode)
                {
                    return View("~/Views/BookingConfirmation/Index.cshtml", model);  // Redirecter til en side, der bekræfter bookingen
                }

                ModelState.AddModelError(string.Empty, "Noget gik galt, prøv igen.");


                //return View (model);
                // If we just 'return View(model)', we're trying to find a View titled like this method (AKA 'ValidationTest' which doesn't exist)
                // So we manually point to where we want to look & what View to look for
                ; // DO NOT USE REDIRECT ; 'cause it loses the model, since it triggers a new 'request'
                // Brug de valgte oplysninger som nødvendigt
                // F.eks. Gem data i en database, vis det på en ny side, osv.

            }
                // Error scenario

                // If we go to another View, a new request is triggered and the validation error data is lost
                // So we need to ensure we go back to the specific View we came from
                // Since we already hit this BookingConfirmationController, if we pass "Index", it'll be BookingConfirmation's Index, which isn't the one we want --
                // -- We specifically want RentOrder's Index, since that's where our forms & validation occurred, so we specifically return that View here-under
                return View("~/Views/RentOrder/Index.cshtml", model);
            
        }

    }
}

