using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRestaurantApi.Models
{
    public partial class Zones
    {
        public Zones()
        {
            
        }
        [Key]
        public int ZoneId { get; set; }
        public int? BranchId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneImage { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        public int? ZoneEnabled { get; set; }
        public int NbOfTables  { get; set; }

        public virtual RestaurantBranch Branch { get; set; }
        
    }
}
