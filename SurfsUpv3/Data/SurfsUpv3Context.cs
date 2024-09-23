﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurfsUpv3.Models;

namespace SurfsUpv3.Data
{
    public class SurfsUpv3Context : DbContext
    {
        public DbSet<Surfboard> Surfboards { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;

        public SurfsUpv3Context (DbContextOptions<SurfsUpv3Context> options)
            : base(options)
        {

        }

    }
}