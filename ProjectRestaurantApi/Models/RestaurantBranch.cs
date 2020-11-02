using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurantApi.Models
{
    public partial class RestaurantBranch
    {
        public RestaurantBranch()
        {
            
            Zones = new HashSet<Zones>();
        }
        [Key]
        public int BranchId { get; set; }
        public int? RestaurantId { get; set; }
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }
        public long? BranchPhoneNumber { get; set; }
        public string BranchNotes { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        
        public virtual ICollection<Zones> Zones { get; set; }
    }
}
