using Microsoft.AspNetCore.Mvc;
using SurfsUp.Models;

namespace SurfsUp.Controllers
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
