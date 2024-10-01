using Microsoft.AspNetCore.Mvc;

namespace SurfsUpAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        [HttpGet]
        public string GetBookings()
        {
            return "Reading all Bookings";
        }

        [HttpGet("{id}")]
        public string GetBooking(int id)
        {
            return $"Reading Booking with id {id}";
        }

        [HttpPost]
        public string CreateBooking()
        {
            return $"Creating Booking";

        }

        [HttpPatch("{id}")]
        public string UpdateBooking(int id)
        {
            return $"Updating Booking with id {id}";
        }

        [HttpDelete("{id}")]
        public string DeleteBooking(int id)
        {
            return $"Deleting Booking with id {id}";
        }
    }
}
