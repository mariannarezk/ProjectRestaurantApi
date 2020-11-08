using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectRestaurantApi.Migrations
{
    public partial class me : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {










            migrationBuilder.AddColumn<int>(
                name: "EnsembleAddonId",
                table: "Items",
                nullable: true
                );






            migrationBuilder.CreateIndex(
                name: "IX_Items_EnsembleAddonId",
                table: "Items",
                column: "EnsembleAddonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_EnsembleAddOns_EnsembleAddonId",
                table: "Items",
                column: "EnsembleAddonId",
                principalTable: "EnsembleAddOns",
                principalColumn: "EnsembleAddonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_EnsembleAddOns_EnsembleAddonId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_EnsembleAddonId",
                table: "Items");


        }
    }
}

