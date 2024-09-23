using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfsUpv3.Migrations.BookingDetailsMigrations
{
    /// <inheritdoc />
    public partial class InitialCreat1e : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    SelectedSurfboard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentPeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentHours = table.Column<TimeOnly>(type: "time", nullable: false),
                    RentReturn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SurfboardAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
