using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakesShop.Migrations
{
    public partial class adddcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Cake",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
            //        Pond = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
            //        Description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cake", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "User",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
            //        Password = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
            //        Gmail = table.Column<string>(type: "varchar(max)", fixedLength: true, maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_User", x => x.Id);
            //    });


        }

      
    }
}
