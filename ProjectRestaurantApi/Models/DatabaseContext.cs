using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<IngrItemQuantity> IngrItemQuantities { get; set; }
        public DbSet<IngPackageQuantity> IngPackageQuantities { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<MenuCategorie> MenuCategories { get; set; }
        public DbSet<PackageItem> PackageItems { get; set; }
        public DbSet<Packages> Packages { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<AddOnes> AddOnes { get; set; }
        public DbSet<ObligAddOnsItems> ObligAddOnsItems { get; set; }
        public DbSet<OptionalAddonItem> OptionalAddonItems { get; set; }
        public DbSet<EnsembleAddOns> EnsembleAddOns { get; set; }
        public DbSet<EnsembleOptionalRlt> EnsembleOptionalRlt { get; set; }
        public DbSet<IngredientItem> ingredientItems { get; set; }
        public DbSet<Itempackage> itempackages { get; set; }
        public DbSet<Allergens> Allergens { get; set; }
        public DbSet<AllergenItem> AllergenItems { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<RestaurantBranch> RestaurantBranch { get; set; }
        public DbSet<Zones> Zones { get; set; }
    }
}
