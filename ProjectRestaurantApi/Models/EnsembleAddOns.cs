using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class EnsembleAddOns
    {
        [Key]
        public int EnsembleAddonId { get; set; }
        public int MinCount { get; set; } //not necessary
        public int MaxCount { get; set; } //not necessary
        public int MenuId { get; set; }
        public string EnsembleName { get; set; }
    }
}
