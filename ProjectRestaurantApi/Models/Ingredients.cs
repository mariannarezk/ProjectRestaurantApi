using ProjectRestaurantApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurantApi.Models
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            IngPackageQuantity = new HashSet<IngPackageQuantity>();
            IngrItemQuantity = new HashSet<IngrItemQuantity>();
           
        }
        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string IngredientCalories { get; set; }
        public int IngredientQty { get; set; }
        public int BranchId { get; set; }
        public virtual ICollection<IngPackageQuantity> IngPackageQuantity { get; set; }
        public virtual ICollection<IngrItemQuantity> IngrItemQuantity { get; set; }
    }
}
