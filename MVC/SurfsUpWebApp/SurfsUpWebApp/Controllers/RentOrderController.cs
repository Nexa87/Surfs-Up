using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;

namespace SurfsUpWebApp.Controllers
{
    public class RentOrderController : Controller
    {
        public IActionResult Index(string? passedSurfboard)
        {
            return View(model: passedSurfboard); // Because if we pass a string into View() in MVC, it thinks we're looking for a View with that string as its name
        }
    }
}
