using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurantApi.Models
{
    public partial class PackageItem //not nessecary
    {
        [Key]
        public int ItemPackageId { get; set; }
        public int ItemId { get; set; }
        public int PackageId { get; set; }
        public double? ItemQtyId { get; set; }
        public string ReplacedBy { get; set; }
        public bool? ItemIsReplaced { get; set; }

      
    }
}
