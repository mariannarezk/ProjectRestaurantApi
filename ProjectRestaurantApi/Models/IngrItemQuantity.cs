using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurantApi.Models
{
    public partial class IngrItemQuantity
    {
        [Key]
        public int IngredientItemId { get; set; }
        public int IngredientId { get; set; }
        public int ItemId { get; set; }
        public double? IngQuantity { get; set; }
        public double? IQuantity { get; set; }
        public string Unite { get; set; }
        public virtual Ingredients Ingredient { get; set; }
        public virtual Items Item { get; set; }
    }
}
