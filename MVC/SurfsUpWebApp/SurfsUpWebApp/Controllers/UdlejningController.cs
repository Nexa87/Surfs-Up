using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    public class UdlejningController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
