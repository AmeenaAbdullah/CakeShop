using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakesShop.Migrations
{
    public partial class addcakecol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Cake",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Cake");
        }
    }
}
