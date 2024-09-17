using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;

namespace SurfsUpWebApp.Controllers
{
    public class UdlejningController : Controller
    {
        public IActionResult Index()
        {
            var repo = new SurfboardRepository();
            return View(repo);
        }

    }
}
