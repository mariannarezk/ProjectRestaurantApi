using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class EnsembleOptionalRlt //btw ensemble and addones

    {
        [Key]
        public int RltId { get; set; }
        public int EnsembleId { get; set; }
        public int AddOnId { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
    }
}
