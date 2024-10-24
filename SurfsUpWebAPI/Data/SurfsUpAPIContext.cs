﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurfsUpWebAPI.Models;
using static SurfsUpWebAPI.Models.WetSuit;

namespace SurfsUpWebAPI.Data
{
    public class SurfsUpAPIContext : DbContext
    {
        
        public SurfsUpAPIContext(DbContextOptions<SurfsUpAPIContext> options)
            : base(options)
        {

        }
        public DbSet<Surfboard> Surfboards { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<WetSuit> WetSuits { get; set; } = default!;
        public DbSet<SiteLog> SiteLogs { get; set; } // For logging 404 & API calls

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konvertering af Gender enum til string
            var genderConverter = new ValueConverter<WetSuitGender, string>(
                v => v.ToString(),
                v => (WetSuitGender)Enum.Parse(typeof(WetSuitGender), v)
            );

            var sizeConverter = new ValueConverter<WetSuitSize, string>(
                v => v.ToString(),
                v => (WetSuitSize)Enum.Parse(typeof(WetSuitSize), v)
            );

            modelBuilder.Entity<Booking>()
                .Property(b => b.Gender)
                .HasConversion(genderConverter);

            modelBuilder.Entity<Booking>()
                .Property(b => b.Size)
                .HasConversion(sizeConverter);
        }

    }
}
