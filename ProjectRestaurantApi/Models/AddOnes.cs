using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class AddOnes
    {

        [Key]
        public int AddOnesId { get; set; }
        public string AddOnesName { get; set; }
        public string AddOnesSize { get; set; }
        public string AddOnesPrice { get; set; }

    }
}
