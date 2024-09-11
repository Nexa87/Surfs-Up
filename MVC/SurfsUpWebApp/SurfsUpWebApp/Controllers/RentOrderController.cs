using Microsoft.AspNetCore.Mvc;
using SurfsUpWebApp.Models;

namespace SurfsUpWebApp.Controllers
{
    public class RentOrderController : Controller
    {
        SurfboardRepository surfboardRepo = new SurfboardRepository();

        public IActionResult Index(string? passedSurfboard)
        {
            var newBoard = surfboardRepo.Get_Surfboard_ByBoardName (passedSurfboard); // This is the way Frankie does it ; we have to create a new instance here, and pass it along below

            return View(newBoard); // NOTE : If we pass a string into View() in MVC, it thinks we're looking for a View with that string as its name | If we need to do this, do 'View(model: myString)'
        }
    }
}
