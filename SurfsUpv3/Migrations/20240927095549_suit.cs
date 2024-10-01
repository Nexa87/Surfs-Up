using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurfsUpv3.Migrations
{
    /// <inheritdoc />
    public partial class suit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "wetSuitGender",
                table: "WetSuits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wetSuitGender",
                table: "WetSuits");
        }
    }
}
