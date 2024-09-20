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
        [HttpPost]
        public IActionResult Index(Booking model)
        {
            // Indlæs priserne fra en kilde, hvis nødvendigt
            var priceOptions = new Dictionary<int, string>
        {
            { 1, "299 kr." },
            { 3, "599 kr." },
            { 24, "799 kr." },
            { 72, "999 kr." },
            { 168, "1299 kr." }
        };
            Console.WriteLine($"Selected Price: {model.RentHours}");

            // Find den valgte pris tekst
            if (priceOptions.TryGetValue(model.Price, out var selectedPrice))
            {
                model.SelectedPrice = selectedPrice;
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
