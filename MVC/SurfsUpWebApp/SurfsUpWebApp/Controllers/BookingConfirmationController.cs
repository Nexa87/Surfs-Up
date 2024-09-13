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
        public IActionResult Index(Booking passedBooking)
        {
            var passedBoard = passedBooking.SelectedSurfboard;
            var booking = passedBooking;
            return View(passedBooking);
        }

    }
}
