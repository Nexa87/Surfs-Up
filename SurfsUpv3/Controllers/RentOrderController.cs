using Microsoft.AspNetCore.Mvc;
using SurfsUp.Models;

namespace SurfsUp.Controllers
{
    public class RentOrderController : Controller
    {
        public IActionResult Index(string? passedSurfboard)
        {
            // Create the Repo to get the board requested
            SurfboardRepository surfboardRepo = new SurfboardRepository ();

            // Create a Booking object, we will pass to the RentOrder View we're headed to
            Booking booking = new Booking ();

            // Set this new Booking's board to the one we got from our parameter (that came from Udlejning)
            var foundBoard = surfboardRepo.Get_Surfboard_ByBoardName (passedSurfboard);
            if (foundBoard != null)
                booking.SelectedSurfboard = foundBoard.BoardName;

            // Pass our Booking forward, heading to RentOrder
            return View(booking); // NOTE : If we pass a string into View() in MVC, it thinks we're looking for a View with that string as its name | If we need to do this, do 'View(model: myString)'
        }
    }
}
