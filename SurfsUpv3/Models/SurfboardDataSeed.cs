using Microsoft.EntityFrameworkCore;
using SurfsUpv3.Data;

namespace SurfsUpv3.Models
{
    public class SurfboardDataSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SurfsUpv3Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<SurfsUpv3Context>>()))
            {
                // Look for any surfboard.
                if (context.Surfboards.Any())
                {
                    return;   // DB has been seeded
                }
                context.Surfboards.AddRange(
                    new Surfboard { BoardName = "The Minilog", Length = 6, Width = 21, Thickness = 2.75f, Volume = 38.8f, /*Surfboard.BoardType.Shortboard,*/ Price = 565, Equipment = "" },
                    new Surfboard { BoardName = "The Wide Glider", Length = 7.1f, Width = 21.75f, Thickness = 2.75f, Volume = 44.16f, /*Surfboard.BoardType.Funboard,*/ Price = 685, Equipment = "" },
                    new Surfboard { BoardName = "The Golden Ratio", Length = 6.3f, Width = 21.85f, Thickness = 2.9f, Volume = 43.22f, /*Surfboard.BoardType.Funboard,*/  Price = 695, Equipment = "" },
                    new Surfboard { BoardName = "Mahi Mahi", Length = 5.4f, Width = 20.75f, Thickness = 2.3f, Volume = 29.39f, /*Surfboard.BoardType.Fish,*/ Price = 645, Equipment = "" },
                    new Surfboard { BoardName = "The Emerald Glider", Length = 9.2f, Width = 22.8f, Thickness = 2.8f, Volume = 65.4f, /*Surfboard.BoardType.Longboard,*/Price = 895, Equipment = "" },
                    new Surfboard { BoardName = "The Bomb", Length = 5.5f, Width = 21f, Thickness = 2.5f, Volume = 33.7f, /*Surfboard.BoardType.Shortboard,*/Price = 645, Equipment = "" },
                    new Surfboard { BoardName = "Walden Magic", Length = 9.6f, Width = 19.4f, Thickness = 3f, Volume = 80f, /*Surfboard.BoardType.Longboard,*/ Price = 1025, Equipment = "" },
                    new Surfboard { BoardName = "Naish One", Length = 12.6f, Width = 30f, Thickness = 6f, Volume = 301f, /*Surfboard.BoardType.SUP,*/ Price = 854, Equipment = "Paddle" },
                    new Surfboard { BoardName = "Six Tourer", Length = 11.6f, Width = 32f, Thickness = 6f, Volume = 270f, /*Surfboard.BoardType.SUP,*/ Price = 611, Equipment = "Fin, Paddle, Pump, Leash" },
                    new Surfboard { BoardName = "Naish Maliko", Length = 14f, Width = 25f, Thickness = 6f, Volume = 330f, /*Surfboard.BoardType.SUP,*/ Price = 1304, Equipment = "Fin, Paddle, Pump, Leash" }
                );

                context.SaveChanges();

            }
        }
    }
}
