using Microsoft.AspNetCore.Mvc;
using SurfsUpAPI;
using SurfsUpAPI.Models;

namespace SurfsUpAPI.Controllers
{
    public class WetsuitController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class WetSuitController : ControllerBase
        {
            private readonly SurfsUpv3Context _context;

            public WetSuitController(SurfsUpv3Context context)
            {
                _context = context;
            }

            [HttpGet("available")]
            public IActionResult GetAvailableWetSuits(string gender)
            {
                var availableSuits = _context.WetSuits
                    .Where(w => w.wetSuitGender == Enum.Parse<WetSuit.WetSuitGender>(gender))
                    .GroupBy(w => w.wetSuitSize)
                    .Select(group => new
                    {
                        Size = group.Key.ToString(),
                        Stock = group.Sum(w => w.Stock)
                    }).ToList();

                return Ok(availableSuits);
            }
        }
        [HttpPost]
        public IActionResult SubmitOrder(List<SurfsUpv3.Models.WetSuit> wetsuitOrders)
        {
            foreach (var order in wetsuitOrders)
            {
                // Tjek hvor mange våddragter af den ønskede størrelse og køn der er på lager
                var availableStock = _context.WetSuits
                    .Where(w => w.Gender == order.Gender && w.Size == order.Size)
                    .Sum(w => w.Stock);

                if (availableStock < order.QuantityOrdered)
                {
                    return BadRequest($"Ikke nok våddragter af størrelse {order.Size} og køn {order.Gender} på lager.");
                }

                // Reducer lager
                var wetsuitsToUpdate = _context.WetSuits
                    .Where(w => w.Gender == order.Gender && w.Size == order.Size)
                    .Take(order.QuantityOrdered);

                foreach (var wetsuit in wetsuitsToUpdate)
                {
                    wetsuit.Stock -= 1;
                }
            }

            // Gem opdateringer i databasen
            _context.SaveChanges();

            return Ok("Bestilling gennemført");
        }


    }
}
