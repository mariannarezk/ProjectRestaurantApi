using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class ObligAddOnsItems
    {
        [Key]
        public int ObligId { get; set; }
        public int ItemId { get; set; }
        public int AddOnsId { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
    }
}
