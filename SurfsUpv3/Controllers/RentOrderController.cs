using Microsoft.AspNetCore.Mvc;
using SurfsUpAPI.Models;

namespace SurfsUpWebApp.Controllers
{
    public class RentOrderController : Controller
    {
        
        public IActionResult Index(string? passedSurfboard)
        {
            var booking = new Booking(passedSurfboard);

            return View(booking); // NOTE : If we pass a string into View() in MVC, it thinks we're looking for a View with that string as its name | If we need to do this, do 'View(model: myString)'
        }
    }
}
