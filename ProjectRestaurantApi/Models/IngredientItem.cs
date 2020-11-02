using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class IngredientItem
    {
        [Key]
        public int IngredientItemId { get; set; }
        public int ItemId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
    }
}
