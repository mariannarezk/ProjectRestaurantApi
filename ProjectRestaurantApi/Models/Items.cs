using ProjectRestaurantApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRestaurantApi.Models
{
    public partial class Items
    {
        public Items()
        {
            IngrItemQuantity = new HashSet<IngrItemQuantity>();
            PackageItem = new HashSet<PackageItem>();
        }
        [Key]
        public int ItemId { get; set; }
        public int? CategId { get; set; }
        public int? SectionId { get; set; }
        public int? Menu_Id { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public bool? ItemStatus { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCalories { get; set; }
        public string ItemSize { get; set; }
      
        public string ItemDiscount { get; set; }
        public string ItemImage { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        public bool? ItemEnable { get; set; }
          
        public virtual Categories Categ { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Sections Section { get; set; }
        public virtual ICollection<IngrItemQuantity> IngrItemQuantity { get; set; }
        public virtual ICollection<PackageItem> PackageItem { get; set; }

        public int NumberAddOns { get; set; }
    
    }
}
