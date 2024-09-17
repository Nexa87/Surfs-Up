using Microsoft.AspNetCore.Mvc;

namespace MVC_Programming_Day_II_29_08_2024.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit (int? id)
        {
            if (id.HasValue)
                return new ContentResult { Content = id.ToString() };
            else
                return new ContentResult { Content = "null content" };
        }
    }
}
