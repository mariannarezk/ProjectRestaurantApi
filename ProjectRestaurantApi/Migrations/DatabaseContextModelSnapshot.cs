﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectRestaurantApi.Models;

namespace ProjectRestaurantApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.AddOnes", b =>
                {
                    b.Property<int>("AddOnesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddOnesName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddOnesPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddOnesSize")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddOnesId");

                    b.ToTable("AddOnes");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.AllergenItem", b =>
                {
                    b.Property<int>("AllergenItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllergenId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("AllergenItemId");

                    b.ToTable("AllergenItems");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Allergens", b =>
                {
                    b.Property<int>("AllergenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AllergenDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AllergenName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergenId");

                    b.ToTable("Allergens");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Categories", b =>
                {
                    b.Property<int>("CategId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategVisible")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.HasKey("CategId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.EnsembleAddOns", b =>
                {
                    b.Property<int>("EnsembleAddonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnsembleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxCount")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("MinCount")
                        .HasColumnType("int");

                    b.HasKey("EnsembleAddonId");

                    b.ToTable("EnsembleAddOns");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.EnsembleOptionalRlt", b =>
                {
                    b.Property<int>("RltId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddOnId")
                        .HasColumnType("int");

                    b.Property<int>("EnsembleId")
                        .HasColumnType("int");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("RltId");

                    b.ToTable("EnsembleOptionalRlt");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.IngPackageQuantity", b =>
                {
                    b.Property<int>("PackageIngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("IngPackageQuantity1")
                        .HasColumnType("float");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.HasKey("PackageIngredientId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("PackageId");

                    b.ToTable("IngPackageQuantities");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.IngrItemQuantity", b =>
                {
                    b.Property<int>("IngredientItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("IQuantity")
                        .HasColumnType("float");

                    b.Property<double?>("IngQuantity")
                        .HasColumnType("float");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Unite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientItemId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("ItemId");

                    b.ToTable("IngrItemQuantities");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.IngredientItem", b =>
                {
                    b.Property<int>("IngredientItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IngredientItemId");

                    b.ToTable("ingredientItems");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Ingredients", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("IngredientCalories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IngredientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IngredientQty")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Itempackage", b =>
                {
                    b.Property<int>("Itempackageid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("ItemQuantity")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.HasKey("Itempackageid");

                    b.ToTable("itempackages");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Items", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategId")
                        .HasColumnType("int");

                    b.Property<string>("ItemCalories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemDiscount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ItemEnable")
                        .HasColumnType("bit");

                    b.Property<string>("ItemImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ItemStatus")
                        .HasColumnType("bit");

                    b.Property<int?>("Menu_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Menu_Id1")
                        .HasColumnType("int");

                    b.Property<int>("NumberAddOns")
                        .HasColumnType("int");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("CategId");

                    b.HasIndex("Menu_Id1");

                    b.HasIndex("SectionId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Menu", b =>
                {
                    b.Property<int>("Menu_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Menu_Active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Menu_Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Menu_Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.MenuCategorie", b =>
                {
                    b.Property<int>("MenuCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("CategEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("CategId")
                        .HasColumnType("int");

                    b.Property<int>("Menu_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Menu_Id1")
                        .HasColumnType("int");

                    b.HasKey("MenuCategoryId");

                    b.HasIndex("CategId");

                    b.HasIndex("Menu_Id1");

                    b.ToTable("MenuCategories");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.ObligAddOnsItems", b =>
                {
                    b.Property<int>("ObligId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddOnsId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ObligId");

                    b.ToTable("ObligAddOnsItems");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.OptionalAddonItem", b =>
                {
                    b.Property<int>("OptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnsembleId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("OptId");

                    b.ToTable("OptionalAddonItems");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.PackageItem", b =>
                {
                    b.Property<int>("ItemPackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<bool?>("ItemIsReplaced")
                        .HasColumnType("bit");

                    b.Property<double?>("ItemQtyId")
                        .HasColumnType("float");

                    b.Property<int?>("ItemsItemId")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int?>("PackagesPackageId")
                        .HasColumnType("int");

                    b.Property<string>("ReplacedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemPackageId");

                    b.HasIndex("ItemsItemId");

                    b.HasIndex("PackagesPackageId");

                    b.ToTable("PackageItems");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Packages", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategId")
                        .HasColumnType("int");

                    b.Property<int?>("Menu_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Menu_Id1")
                        .HasColumnType("int");

                    b.Property<double?>("PackageDiscount")
                        .HasColumnType("float");

                    b.Property<bool?>("PackageEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PackageOffer")
                        .HasColumnType("bit");

                    b.Property<double?>("PackagePrice")
                        .HasColumnType("float");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("PackageId");

                    b.HasIndex("CategId");

                    b.HasIndex("Menu_Id1");

                    b.HasIndex("SectionId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RestNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantActive")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.RestaurantBranch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("BranchPhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("BranchId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantBranch");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Sections", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Menu_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Menu_Id1")
                        .HasColumnType("int");

                    b.Property<string>("SectionAvailable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionId");

                    b.HasIndex("Menu_Id1");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Zones", b =>
                {
                    b.Property<int>("ZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("NbOfTables")
                        .HasColumnType("int");

                    b.Property<int?>("ZoneEnabled")
                        .HasColumnType("int");

                    b.Property<string>("ZoneImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZoneName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZoneId");

                    b.HasIndex("BranchId");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasIndex("RestaurantId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.IngPackageQuantity", b =>
                {
                    b.HasOne("ProjectRestaurantApi.Models.Ingredients", "Ingredient")
                        .WithMany("IngPackageQuantity")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectRestaurantApi.Models.Packages", "Package")
                        .WithMany("IngPackageQuantity")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.IngrItemQuantity", b =>
                {
                    b.HasOne("ProjectRestaurantApi.Models.Ingredients", "Ingredient")
                        .WithMany("IngrItemQuantity")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectRestaurantApi.Models.Items", "Item")
                        .WithMany("IngrItemQuantity")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Items", b =>
                {
                    b.HasOne("ProjectRestaurantApi.Models.Categories", "Categ")
                        .WithMany("Items")
                        .HasForeignKey("CategId");

                    b.HasOne("ProjectRestaurantApi.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("Menu_Id1");

                    b.HasOne("ProjectRestaurantApi.Models.Sections", "Section")
                        .WithMany("Items")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.MenuCategorie", b =>
                {
                    b.HasOne("ProjectRestaurantApi.Models.Categories", "Categ")
                        .WithMany("MenuCategorie")
                        .HasForeignKey("CategId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectRestaurantApi.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("Menu_Id1");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.PackageItem", b =>
                {
                    b.HasOne("ProjectRestaurantApi.Models.Items", null)
                        .WithMany("PackageItem")
                        .HasForeignKey("ItemsItemId");

                    b.HasOne("ProjectRestaurantApi.Models.Packages", null)
                        .WithMany("PackageItem")
                        .HasForeignKey("PackagesPackageId");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Packages", b =>
                {
                    b.HasOne("ProjectRestaurantApi.Models.Categories", "Categ")
                        .WithMany("Packages")
                        .HasForeignKey("CategId");

                    b.HasOne("ProjectRestaurantApi.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("Menu_Id1");

                    b.HasOne("ProjectRestaurantApi.Models.Sections", "Section")
                        .WithMany("Packages")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.RestaurantBranch", b =>
                {
                    b.HasOne("ProjectRestaurantApi.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantBranch")
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Sections", b =>
                {
                    b.HasOne("ProjectRestaurantApi.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("Menu_Id1");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.Zones", b =>
                {
                    b.HasOne("ProjectRestaurantApi.Models.RestaurantBranch", "Branch")
                        .WithMany("Zones")
                        .HasForeignKey("BranchId");
                });

            modelBuilder.Entity("ProjectRestaurantApi.Models.ApplicationUser", b =>
                {
                    b.HasOne("ProjectRestaurantApi.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId");
                });
#pragma warning restore 612, 618
        }
    }
}
