using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebApp.Controllers
{
    public class RentOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
