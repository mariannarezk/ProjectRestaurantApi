using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectRestaurantApi.Migrations
{
    public partial class noram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantActive",
                table: "Restaurant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Restaurant_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Restaurant_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantActive",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "AspNetUsers");


            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

           
        }
    }
}
