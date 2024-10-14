using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfsUpWebAPI.Migrations.SurfsUpv3
{
    /// <inheritdoc />
    public partial class wetsuitid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "WetsuitId",
                table: "Bookings");
        }
    }
}
