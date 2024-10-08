﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurfsUpWebAPI.Data;

#nullable disable

namespace SurfsUpWebAPI.Migrations
{
    [DbContext(typeof(SurfsUpv3Context))]
    [Migration("20241004084754_apicall")]
    partial class apicall
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SurfsUpWebAPI.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("RentHours")
                        .HasColumnType("time");

                    b.Property<DateTime>("RentPeriod")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentReturn")
                        .HasColumnType("datetime2");

                    b.Property<string>("SelectedSurfboard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SurfboardAmount")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("SurfsUpWebAPI.Models.WetSuit", b =>
                {
                    b.Property<int>("WetSuitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WetSuitId"));

                    b.Property<int>("wetSuitGender")
                        .HasColumnType("int");

                    b.Property<int>("wetSuitSize")
                        .HasColumnType("int");

                    b.HasKey("WetSuitId");

                    b.ToTable("WetSuits");
                });

            modelBuilder.Entity("SurfsUpWebAPI.Surfboard", b =>
                {
                    b.Property<int>("SurfboardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SurfboardId"));

                    b.Property<string>("BoardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<float>("Thickness")
                        .HasColumnType("real");

                    b.Property<float>("Volume")
                        .HasColumnType("real");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("SurfboardId");

                    b.ToTable("Surfboards");
                });
#pragma warning restore 612, 618
        }
    }
}
