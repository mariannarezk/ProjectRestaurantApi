using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class AllergenItemViewModel
    {
        public int AllergenId { get; set; }
        public int ItemId { get; set; }
        public string AllergenName { get; set; }
        public bool IsChoosed { get; set; }
    }
}
