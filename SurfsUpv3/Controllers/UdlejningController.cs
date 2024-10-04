using Microsoft.AspNetCore.Mvc;

using SurfsUpv3.Models;

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
