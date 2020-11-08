using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class RestaurantManagerBindingModel
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantLogo { get; set; }
        public string? RestPhoneNumber { get; set; }
        public string RestNotes { get; set; }
        public int RestaurantActive { get; set; }
        public string userid { get; set; }
        public string managerfullname { get; set; }
        public string manageremail { get; set; }
        public int active { get; set; }
    }
}
