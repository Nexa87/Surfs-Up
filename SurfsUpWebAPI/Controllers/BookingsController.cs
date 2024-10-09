using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebAPI.Controllers
{
    [ApiController]
    [Route("bookings")]
    public class BookingsController
    {
        [HttpGet]
        public string Bookings ()
        {
            // Test comment
            return $"All the bookings";
        }
    }
}
