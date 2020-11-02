using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurantApi.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            RestaurantBranch = new HashSet<RestaurantBranch>();
        }
        [Key]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantLogo { get; set; }
        public string? RestPhoneNumber { get; set; }
        public string RestNotes { get; set; }

        public virtual ICollection<RestaurantBranch> RestaurantBranch { get; set; }
    }
}
