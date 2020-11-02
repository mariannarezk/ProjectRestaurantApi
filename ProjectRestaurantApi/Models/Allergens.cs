using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class Allergens
    {
        [Key]
        public int AllergenId { get; set; }
        public string AllergenName { get; set; }
        public string AllergenDescription { get; set; }

    }
}
