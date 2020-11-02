using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class EnsembleItemViewModel //this is for the ensembles showed in the items section
    {
        public int EnsembleId { get; set; }
        public int ItemId { get; set; }
        public string EnsembleName { get; set; }
        public bool IsChoosed { get; set; }
    }
}
