using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;

namespace SurfsUpWebApp.Controllers
{
    public class BookingConfirmationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Booking model)
        {
            // Indlæs priserne fra en kilde, hvis nødvendigt
            var priceOptions = new Dictionary<float, float>
        {
            { 1, 299 },
            { 3, 599 },
            { 24, 799 },
            { 72, 999 },
            { 168, 1299 }
        };
            Console.WriteLine($"Selected Price: {model.RentHours}");

            // Find den valgte pris tekst
            if (priceOptions.TryGetValue(model.Price, out var selectedPrice))
            {
                model.SelectedPrice = selectedPrice.ToString();
            }
            else
            {
                model.SelectedPrice = "Ingen gyldig periode valgt";
            }
            var passedBoard = model.SelectedSurfboard;
            var booking = model;
            return View( model);
            // Brug de valgte oplysninger som nødvendigt
            // F.eks. Gem data i en database, vis det på en ny side, osv.

            

        }



    }
}
