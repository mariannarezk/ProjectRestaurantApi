using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectRestaurantApi.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddOnes",
                columns: table => new
                {
                    AddOnesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddOnesName = table.Column<string>(nullable: true),
                    AddOnesSize = table.Column<string>(nullable: true),
                    AddOnesPrice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOnes", x => x.AddOnesId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategName = table.Column<string>(nullable: true),
                    CategDescription = table.Column<string>(nullable: true),
                    CategVisible = table.Column<string>(nullable: true),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategId);
                });

            migrationBuilder.CreateTable(
                name: "EnsembleAddOns",
                columns: table => new
                {
                    EnsembleAddonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinCount = table.Column<int>(nullable: false),
                    MaxCount = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsembleAddOns", x => x.EnsembleAddonId);
                });

            migrationBuilder.CreateTable(
                name: "EnsembleOptionalRlt",
                columns: table => new
                {
                    RltId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnsembleId = table.Column<int>(nullable: false),
                    AddOnId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsembleOptionalRlt", x => x.RltId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(nullable: true),
                    IngredientCalories = table.Column<string>(nullable: true),
                    IngredientQty = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Menu_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Title = table.Column<string>(nullable: true),
                    Menu_Active = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Menu_Id);
                });

            migrationBuilder.CreateTable(
                name: "ObligAddOnsItems",
                columns: table => new
                {
                    ObligId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    AddOnsId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObligAddOnsItems", x => x.ObligId);
                });

            migrationBuilder.CreateTable(
                name: "OptionalAddonItems",
                columns: table => new
                {
                    OptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnsembleId = table.Column<int>(nullable: false),
                    AddOnId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalAddonItems", x => x.OptId);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    MenuCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Id = table.Column<int>(nullable: false),
                    CategId = table.Column<int>(nullable: false),
                    CategEnabled = table.Column<bool>(nullable: true),
                    Menu_Id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.MenuCategoryId);
                    table.ForeignKey(
                        name: "FK_MenuCategories_Categories_CategId",
                        column: x => x.CategId,
                        principalTable: "Categories",
                        principalColumn: "CategId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuCategories_Menus_Menu_Id1",
                        column: x => x.Menu_Id1,
                        principalTable: "Menus",
                        principalColumn: "Menu_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Id = table.Column<int>(nullable: true),
                    SectionName = table.Column<string>(nullable: true),
                    SectionAvailable = table.Column<string>(nullable: true),
                    Menu_Id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Menus_Menu_Id1",
                        column: x => x.Menu_Id1,
                        principalTable: "Menus",
                        principalColumn: "Menu_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategId = table.Column<int>(nullable: true),
                    SectionId = table.Column<int>(nullable: true),
                    Menu_Id = table.Column<int>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<string>(nullable: true),
                    ItemStatus = table.Column<bool>(nullable: true),
                    ItemDescription = table.Column<string>(nullable: true),
                    ItemCalories = table.Column<string>(nullable: true),
                    ItemSize = table.Column<string>(nullable: true),
                    ItemDiscount = table.Column<string>(nullable: true),
                    ItemImage = table.Column<string>(nullable: true),
                    ItemEnable = table.Column<bool>(nullable: true),
                    Menu_Id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategId",
                        column: x => x.CategId,
                        principalTable: "Categories",
                        principalColumn: "CategId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Menus_Menu_Id1",
                        column: x => x.Menu_Id1,
                        principalTable: "Menus",
                        principalColumn: "Menu_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Id = table.Column<int>(nullable: true),
                    SectionId = table.Column<int>(nullable: true),
                    CategId = table.Column<int>(nullable: true),
                    PackageName = table.Column<string>(nullable: true),
                    PackagePrice = table.Column<double>(nullable: true),
                    PackageDiscount = table.Column<double>(nullable: true),
                    PackageOffer = table.Column<bool>(nullable: true),
                    PackageEnabled = table.Column<bool>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    Menu_Id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Packages_Categories_CategId",
                        column: x => x.CategId,
                        principalTable: "Categories",
                        principalColumn: "CategId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Packages_Menus_Menu_Id1",
                        column: x => x.Menu_Id1,
                        principalTable: "Menus",
                        principalColumn: "Menu_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Packages_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngrItemQuantities",
                columns: table => new
                {
                    IngredientItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    IngQuantity = table.Column<double>(nullable: true),
                    IQuantity = table.Column<double>(nullable: true),
                    Unite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngrItemQuantities", x => x.IngredientItemId);
                    table.ForeignKey(
                        name: "FK_IngrItemQuantities_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngrItemQuantities_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngPackageQuantities",
                columns: table => new
                {
                    PackageIngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    IngPackageQuantity1 = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngPackageQuantities", x => x.PackageIngredientId);
                    table.ForeignKey(
                        name: "FK_IngPackageQuantities_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngPackageQuantities_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageItems",
                columns: table => new
                {
                    ItemPackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    PackageId = table.Column<int>(nullable: false),
                    ItemQtyId = table.Column<double>(nullable: true),
                    ReplacedBy = table.Column<string>(nullable: true),
                    ItemIsReplaced = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageItems", x => x.ItemPackageId);
                   
                  
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngPackageQuantities_IngredientId",
                table: "IngPackageQuantities",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngPackageQuantities_PackageId",
                table: "IngPackageQuantities",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_IngrItemQuantities_IngredientId",
                table: "IngrItemQuantities",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngrItemQuantities_ItemId",
                table: "IngrItemQuantities",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategId",
                table: "Items",
                column: "CategId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Menu_Id1",
                table: "Items",
                column: "Menu_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SectionId",
                table: "Items",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategories_CategId",
                table: "MenuCategories",
                column: "CategId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategories_Menu_Id1",
                table: "MenuCategories",
                column: "Menu_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_PackageItems_ItemId",
                table: "PackageItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageItems_PackageId",
                table: "PackageItems",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CategId",
                table: "Packages",
                column: "CategId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Menu_Id1",
                table: "Packages",
                column: "Menu_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_SectionId",
                table: "Packages",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_Menu_Id1",
                table: "Sections",
                column: "Menu_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddOnes");

            migrationBuilder.DropTable(
                name: "EnsembleAddOns");

            migrationBuilder.DropTable(
                name: "EnsembleOptionalRlt");

            migrationBuilder.DropTable(
                name: "IngPackageQuantities");

            migrationBuilder.DropTable(
                name: "IngrItemQuantities");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropTable(
                name: "ObligAddOnsItems");

            migrationBuilder.DropTable(
                name: "OptionalAddonItems");

            migrationBuilder.DropTable(
                name: "PackageItems");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
