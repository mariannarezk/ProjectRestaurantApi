using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class ObligAdonItemViewModel
    {
       public int ItemId { get; set; }
        public int AddonId { get; set; }
        public string AddonName { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public bool IsChoosed { get; set; }
    }
}
