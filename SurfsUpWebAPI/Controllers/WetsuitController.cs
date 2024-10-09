using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebAPI.Data;
using SurfsUpWebAPI.Models;

namespace SurfsUpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WetsuitController : ControllerBase
    {
        private readonly SurfsUpv3Context _context;

        public WetsuitController(SurfsUpv3Context context)
        {
            _context = context;
        }

        // GET: api/WetSuit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WetSuit>>> GetWetSuits()
        {
            return await _context.WetSuits.ToListAsync();
        }

        // GET: api/WetSuit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WetSuit>> GetWetSuit(int id)
        {
            var wetSuit = await _context.WetSuits.FindAsync(id);

            if (wetSuit == null)
            {
                return NotFound();
            }

            return wetSuit;
        }

        // POST: api/WetSuit
        [HttpPost]
        public async Task<ActionResult<WetSuit>> PostWetSuit(WetSuit wetSuit)
        {
            _context.WetSuits.Add(wetSuit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWetSuit), new { id = wetSuit.WetSuitId }, wetSuit);
        }

        // PUT: api/WetSuit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWetSuit(int id, WetSuit wetSuit)
        {
            if (id != wetSuit.WetSuitId)
            {
                return BadRequest();
            }

            _context.Entry(wetSuit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WetSuitExists(id))
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

        // DELETE: api/WetSuit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWetSuit(int id)
        {
            var wetSuit = await _context.WetSuits.FindAsync(id);
            if (wetSuit == null)
            {
                return NotFound();
            }

            _context.WetSuits.Remove(wetSuit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WetSuitExists(int id)
        {
            return _context.WetSuits.Any(e => e.WetSuitId == id);
        }
    }
}

