using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectRestaurantApi.Migrations
{
    public partial class ma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    AllergenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergenName = table.Column<string>(nullable: true),
                    AllergenDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.AllergenId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergens");
        }
    }
}
