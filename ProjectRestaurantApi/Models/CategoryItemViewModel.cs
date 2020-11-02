using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class CategoryItemViewModel
    {
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string ItemName { get; set; }
        public bool IsChoosed { get; set; } //is choosed for this category or not
      
    }
}
