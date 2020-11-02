using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class AllergenItem
    {
        [Key]
        public int AllergenItemId { get; set; }
        public int AllergenId { get; set; }
        public int ItemId { get; set; }
    }
}
