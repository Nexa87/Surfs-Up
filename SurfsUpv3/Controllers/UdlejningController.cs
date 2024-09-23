using Microsoft.AspNetCore.Mvc;
using SurfsUpv3.Data;
using SurfsUpv3.Models;

namespace SurfsUpWebApp.Controllers
{
    public class UdlejningController : Controller
    {

        private readonly SurfsUpv3Context _context;

        public UdlejningController(SurfsUpv3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var surfboard = _context.Surfboards.ToList();
                return View(surfboard);
        }
    }
}
