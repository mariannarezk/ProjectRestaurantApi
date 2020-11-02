using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class ItemIngredientViewModel
    {
        public int IngredientId { get; set; }
        public int ItemId { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
        public bool IsChoosed { get; set; }

    }
}
