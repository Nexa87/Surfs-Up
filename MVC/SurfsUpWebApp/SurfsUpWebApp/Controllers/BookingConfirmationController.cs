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

        public IActionResult Submit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var newbook = booking;
            return View(newbook);
        }
        //[HttpPost]
        //public IActionResult SubmitBooking()
        //{
        //    // Logik til at håndtere booking

        //    // Redirect til Booking Confirmation
        //    return RedirectToAction("BookingConfirmation");
        //}

        //public IActionResult BookingConfirmation()
        //{
        //    return View(); // Returner booking confirmation view
        //}

    }
}
