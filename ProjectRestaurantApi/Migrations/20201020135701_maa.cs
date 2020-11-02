using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectRestaurantApi.Migrations
{
    public partial class maa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllergenItems",
                columns: table => new
                {
                    AllergenItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergenId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenItems", x => x.AllergenItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenItems");
        }
    }
}
