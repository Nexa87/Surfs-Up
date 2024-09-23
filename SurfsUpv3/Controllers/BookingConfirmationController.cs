using Microsoft.AspNetCore.Mvc;
using SurfsUpv3.Data;
using SurfsUpv3.Models;

namespace SurfsUpv3.Controllers
{
    public class BookingConfirmationController : Controller
    {
        private readonly SurfsUpv3Context _context;
        public BookingConfirmationController(SurfsUpv3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(Booking model)
        //{
        //    // Indlæs priserne fra en kilde, hvis nødvendigt
        //    var priceOptions = new Dictionary<int, string>
        //    {
        //        { 1, "299 kr." },
        //        { 3, "599 kr." },
        //        { 24, "799 kr." },
        //        { 72, "999 kr." },
        //        { 168, "1299 kr." }
        //    };
        //    Console.WriteLine($"Selected Price: {model.RentHours}");

        //    // Find den valgte pris tekst
        //    if (priceOptions.TryGetValue(model.Price, out var selectedPrice))
        //    {
        //        model.Price = selectedPrice;
        //    }
        //    else
        //    {
        //        model.SelectedPrice = "Ingen gyldig periode valgt";
        //    }
        //    var passedBoard = model.SelectedSurfboard;
        //    var booking = model;
        //    return View( model);
        //    // Brug de valgte oplysninger som nødvendigt
        //    // F.eks. Gem data i en database, vis det på en ny side, osv.
        //}

        [HttpPost]
        public IActionResult ValidationTest(Booking model)
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

                var bookingdetails = new Booking
                {
                    CustomerName = model.CustomerName,
                    CustomerEmail = model.CustomerEmail,
                    CustomerPhone = model.CustomerPhone,
                    SelectedSurfboard = model.SelectedSurfboard,
                    Remarks = model.Remarks,
                    RentHours = model.RentHours,
                    RentReturn = model.RentReturn,
                    RentPeriod = model.RentPeriod,
                    SurfboardAmount = model.SurfboardAmount,
                    Price = model.Price,
                    //BookingTime = model.BookingTime,

                };
                _context.Bookings.Add(bookingdetails);
                _context.SaveChanges();

                // Find den valgte pris tekst
                if (priceOptions.TryGetValue(model.Price, out var selectedPrice))
                {
                    model.Price = selectedPrice;
                }
                else
                {
                    model.Price = -1; // Value indicating "Something-Went-Wrong"
                }

                var passedBoard = model.SelectedSurfboard;
                var booking = model;

                //return View (model);
                // If we just 'return View(model)', we're trying to find a View titled like this method (AKA 'ValidationTest' which doesn't exist)
                // So we manually point to where we want to look & what View to look for
                return View("~/Views/BookingConfirmation/Index.cshtml", model); // DO NOT USE REDIRECT ; 'cause it loses the model, since it triggers a new 'request'
                // Brug de valgte oplysninger som nødvendigt
                // F.eks. Gem data i en database, vis det på en ny side, osv.

            }
            else
            {
                // Error scenario

                // If we go to another View, a new request is triggered and the validation error data is lost
                // So we need to ensure we go back to the specific View we came from
                // Since we already hit this BookingConfirmationController, if we pass "Index", it'll be BookingConfirmation's Index, which isn't the one we want --
                // -- We specifically want RentOrder's Index, since that's where our forms & validation occurred, so we specifically return that View here-under
                return View("~/Views/RentOrder/Index.cshtml", model);
            }
        }

    }
}
