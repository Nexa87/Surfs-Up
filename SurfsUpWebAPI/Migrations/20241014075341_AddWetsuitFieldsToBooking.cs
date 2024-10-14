using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfsUpWebAPI.Migrations.SurfsUpv3
{
    /// <inheritdoc />
    public partial class AddWetsuitFieldsToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wetSuitGender",
                table: "WetSuits");

            migrationBuilder.DropColumn(
                name: "wetSuitSize",
                table: "WetSuits");

            migrationBuilder.RenameColumn(
                name: "WetSuitId",
                table: "WetSuits",
                newName: "WetsuitId");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "WetSuits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "WetSuits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WetsuitId",
                table: "Bookings",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "WetSuits");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "WetSuits");

            migrationBuilder.DropColumn(
                name: "BookingTime",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "WetsuitId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "WetsuitId",
                table: "WetSuits",
                newName: "WetSuitId");

            migrationBuilder.AddColumn<int>(
                name: "wetSuitGender",
                table: "WetSuits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "wetSuitSize",
                table: "WetSuits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
