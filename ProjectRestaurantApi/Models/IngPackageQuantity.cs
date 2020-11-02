using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurantApi.Models
{
    public partial class IngPackageQuantity
    {
        [Key]
        public int PackageIngredientId { get; set; }
        public int PackageId { get; set; }
        public int IngredientId { get; set; }
        public double? IngPackageQuantity1 { get; set; }

        public virtual Ingredients Ingredient { get; set; }
        public virtual Packages Package { get; set; }
    }
}
