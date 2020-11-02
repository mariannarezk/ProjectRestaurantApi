using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class OptionalAddonItemViewModel
    {
        public int RltId { get; set; }
        public int EnsemleId { get; set; }
        public int AddOnId { get; set; }
        public string AddoneName { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
    }
}
