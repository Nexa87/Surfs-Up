using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    public class BookingConfirmationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
