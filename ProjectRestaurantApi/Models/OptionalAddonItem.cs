using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class OptionalAddonItem
    {
        [Key]
        public int OptId { get; set; }
     
        public int EnsembleId { get; set; }
        public int ItemId { get; set; }
 
    }
}
