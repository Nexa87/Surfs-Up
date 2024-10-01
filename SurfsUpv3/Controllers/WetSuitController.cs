using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfsUpAPI.Data;
using SurfsUpAPI.Models;
namespace SurfsUpv3.Controllers
{
    public class WetSuitController : Controller
    {
        private readonly SurfsUpv3Context _context;

        public WetSuitController(SurfsUpv3Context context)
        {
            _context = context;
        }

        // GET: WetSuits
        public async Task<IActionResult> Index()
        {
            return View(await _context.WetSuits.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wetsuit = await _context.WetSuits
                .FirstOrDefaultAsync(m => m.WetSuitId == id);
            if (wetsuit == null)
            {
                return NotFound();
            }
            return View(wetsuit);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WetSuitId,WetSuitGender,WetSuitSize")] WetSuit wetSuit)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(wetSuit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wetSuit);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wetSuit = await _context.WetSuits.FindAsync(id);
            if (wetSuit == null)
            {
                return NotFound();
            }
            return View(wetSuit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WetSuitId,WetSuitGender,WetSuitSize")] WetSuit wetSuit)
        {
            if (id != wetSuit.WetSuitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wetSuit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WetSuitExists(wetSuit.WetSuitId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(wetSuit);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wetSuit = await _context.WetSuits
                .FirstOrDefaultAsync(m => m.WetSuitId == id);
            if (wetSuit == null)
            {
                return NotFound();
            }

            return View(wetSuit);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wetSuit = await _context.WetSuits.FindAsync(id);
            if (wetSuit != null)
            {
                _context.WetSuits.Remove(wetSuit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WetSuitExists(int Id)
        {
            return _context.WetSuits.Any(e => e.WetSuitId == Id);
        }
    }
}
