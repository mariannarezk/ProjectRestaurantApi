using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string FullName { get; set; }
        public int? RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

    }
}
