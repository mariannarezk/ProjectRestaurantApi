using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectRestaurantApi.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "itempackages",
                columns: table => new
                {
                    Itempackageid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itempackages", x => x.Itempackageid);
                });

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "itempackages");

           
        }
    }
}
