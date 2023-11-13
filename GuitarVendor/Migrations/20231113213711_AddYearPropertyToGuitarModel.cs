using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarVendor.Migrations
{
    public partial class AddYearPropertyToGuitarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Guitars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Guitars");
        }
    }
}
