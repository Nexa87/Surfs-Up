using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebAPI.Data;
using SurfsUpWebAPI.Models;

namespace SurfsUpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly SurfsUpAPIContext _context;

        public BookingController(SurfsUpAPIContext context)
        {
            _context = context;
        }
        // GET: api/Booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // POST: api/Booking
        
        [HttpPost]
        public async Task<ActionResult<Booking>> AddBookingDetailsToAPI( Booking booking)
        {
            if (!ModelState.IsValid)
            {
                              
                return BadRequest(ModelState);
            }

            _context.Bookings.Add(booking);  // _context er din database context
            await _context.SaveChangesAsync();
            // Returner den oprettede booking med status 201 (Created)
            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId, booking.BookingTime }, booking);// bruges til at kunne oplyse bookingId på bookingconfirmation

            
        }


        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking updatedBooking)
        {
            if (id != updatedBooking.BookingId)
            {
                return BadRequest();
            }

            // Does this actually update ? Need to get back and verify this later
            _context.Entry(updatedBooking).State = EntityState.Modified;


            // Find the existing booking; the one we want to update
            var existingBooking = await _context.Bookings.FindAsync(id);

            // Concurrency check: set the original RowVersion from the request
            _context.Entry(existingBooking).OriginalValues["RowVersion"] = updatedBooking.RowVersion;

            // Update whatever it is we want to update
            existingBooking.CustomerName = updatedBooking.CustomerName;
            existingBooking.CustomerEmail = updatedBooking.CustomerEmail;
            existingBooking.CustomerPhone = updatedBooking.CustomerPhone;
            // Assuming we can't change surfboard, since that would require a lot of re-checking if new board is available etc.
            existingBooking.Remarks = updatedBooking.Remarks;
            // Price is also assumed non-updatedable, since this method is most likely called by a customer ?


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle the concurrency conflict
                var entry = ex.Entries.Single();
                var clientValues = (Booking)entry.Entity;
                var databaseEntry = entry.GetDatabaseValues();

                // '== false' more readable in large code-quantity, compared to '!BookingExists(id)'
                if (databaseEntry == null || BookingExists(id) == false)
                {
                    // The entity was deleted by another user
                    return NotFound();
                }
                else
                {
                    var databaseValues = (Booking)databaseEntry.ToObject();

                    // You can inform the client about the conflict and give them the database values
                    ModelState.AddModelError("RowVersion", "The booking you attempted to edit "
                        + "was modified by another user after you got the original value. The "
                        + "edit operation was canceled. If you still want to edit this booking, "
                        + "try again.");

                    return Conflict(ModelState);
                    //throw; // From old if-else, before concurrency check
                }
            }

            return NoContent();
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
