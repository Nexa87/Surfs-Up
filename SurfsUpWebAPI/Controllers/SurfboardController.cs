using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebAPI.Data;
using SurfsUpWebAPI;

namespace SurfsUpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurfboardsController : ControllerBase
    {
        private readonly SurfsUpAPIContext _context;

        public SurfboardsController(SurfsUpAPIContext context)
        {
            _context = context;
        }

        // GET: api/Surfboards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Surfboard>>> GetSurfboards()
        {
            return await _context.Surfboards.ToListAsync();
        }

        // GET: api/Surfboards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Surfboard>> GetSurfboard(int id)
        {
            var surfboard = await _context.Surfboards.FindAsync(id);

            if (surfboard == null)
            {
                return NotFound();
            }

            return surfboard;
        }

        // POST: api/Surfboards
        [HttpPost]
        public async Task<ActionResult<Surfboard>> PostSurfboard(Surfboard surfboard)
        {
            _context.Surfboards.Add(surfboard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSurfboard), new { id = surfboard.SurfboardId }, surfboard);
        }

        // PUT: api/Surfboards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurfboard(int id, Surfboard surfboard)
        {
            if (id != surfboard.SurfboardId)
            {
                return BadRequest();
            }

            _context.Entry(surfboard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurfboardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Surfboards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurfboard(int id)
        {
            var surfboard = await _context.Surfboards.FindAsync(id);
            if (surfboard == null)
            {
                return NotFound();
            }

            _context.Surfboards.Remove(surfboard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurfboardExists(int id)
        {
            return _context.Surfboards.Any(e => e.SurfboardId == id);
        }
    }
}
