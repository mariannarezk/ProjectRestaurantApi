using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class EnsembleAddonsViewModel 
    {
        public int addonid { get; set; }
        public int ensembleid { get; set; }
        public string addonName { get; set; }
        public bool choosed { get; set; }
        public string price { get; set; }
    }
}
