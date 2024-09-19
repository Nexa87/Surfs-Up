using Microsoft.AspNetCore.Mvc;
using SurfsUp.Models;
using System.Reflection;
namespace SurfsUp.Controllers
{
    public class BookingConfirmationController : Controller
    {
        public IActionResult Index (Booking booking)
        {
            // Booking was passed the 'option' selected, into its Price property
            // We need to convert that to the actual price-value, with this dictionary
            var priceOptions = new Dictionary<int, int>
            {
                // Note, the int values are kr. danske ,-
                { 1, 299},
                { 3, 599},
                { 24, 799},
                { 72, 999},
                { 168, 1299}
            };

            if (priceOptions.TryGetValue (booking.Price, out var selectedPrice)) {
                booking.Price= selectedPrice;
            }
            // No need for an else-check here, since we check whether a valid price was chosen, on the RentOrder page

            return View (booking);
        }
    }
}
