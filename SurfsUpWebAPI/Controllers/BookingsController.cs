using Microsoft.AspNetCore.Mvc;

namespace SurfsUpWebAPI.Controllers
{
    [ApiController]
    [Route("bookings")]
    public class BookingsController
    {
        public string Bookings ()
        {
            return $"All the bookings";
        }
    }
}
