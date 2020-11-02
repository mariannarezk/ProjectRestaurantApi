using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurantApi.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Items = new HashSet<Items>();
            MenuCategorie = new HashSet<MenuCategorie>();
            Packages = new HashSet<Packages>();
        }
        [Key]
        public int CategId { get; set; }
        public string CategName { get; set; }
        public string CategDescription { get; set; }
        public string CategVisible { get; set; }
        public int MenuId { get; set; }
        public virtual ICollection<Items> Items { get; set; }
        public virtual ICollection<MenuCategorie> MenuCategorie { get; set; }
        public virtual ICollection<Packages> Packages { get; set; }
    }
}
