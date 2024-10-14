using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebAPI.Models;

namespace SurfsUpWebAPI.Data
{
    public class SurfsUpAPIContext : DbContext
    {
        public DbSet<Surfboard> Surfboards { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<WetSuit> WetSuits { get; set; } = default!;
        public DbSet<SiteLog> SiteLogs { get; set; } // For logging 404 & API calls
        
        public SurfsUpAPIContext (DbContextOptions<SurfsUpAPIContext> options)
            : base(options)
        {

        }

    }
}
