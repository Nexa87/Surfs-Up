using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfsUpv3.Migrations
{
    /// <inheritdoc />
    public partial class Wetsuit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "wetSuitSize",
                table: "WetSuits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wetSuitSize",
                table: "WetSuits");
        }
    }
}
