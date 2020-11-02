using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class Itempackage
    {
        [Key]
        public int Itempackageid { get; set; }
        public int PackageId { get; set; }
        public int ItemId { get; set; }
        public int ItemQuantity { get; set; }
      
    }
}
