using ProjectRestaurantApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurantApi.Models
{
    public partial class Sections
    {
        public Sections()
        {
           
            Items = new HashSet<Items>();
            Packages = new HashSet<Packages>();
        }
        [Key]
        public int SectionId { get; set; }
        public int? Menu_Id { get; set; }
        public string SectionName { get; set; }
        public string SectionAvailable { get; set; }

        public virtual Menu Menu { get; set; }
      
        public virtual ICollection<Items> Items { get; set; }
        public virtual ICollection<Packages> Packages { get; set; }
    }
}
