using Microsoft.AspNetCore.Mvc;

namespace MVC_Programming_Day_II_29_08_2024.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
