using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurfsUpv3.Models;

namespace SurfsUpv3.Data
{
    public class BookingDetails : DbContext
    {
        public DbSet<Booking> Bookings { get; set; } = default!;
        public BookingDetails (DbContextOptions<BookingDetails> options)
            : base(options)
        {
        }

    }
}
