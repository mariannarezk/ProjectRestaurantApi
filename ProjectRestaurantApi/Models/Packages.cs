using ProjectRestaurantApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectRestaurantApi.Models
{
    public partial class Packages
    {
        public Packages()
        {
            IngPackageQuantity = new HashSet<IngPackageQuantity>();
            PackageItem = new HashSet<PackageItem>();
     
        }
        [Key]
        public int PackageId { get; set; }
        public int? Menu_Id { get; set; }
        public int? SectionId { get; set; }
       // public int? OrderPackageId { get; set; }
        public int? CategId { get; set; }
        public string PackageName { get; set; }
        public double? PackagePrice { get; set; }
        public double? PackageDiscount { get; set; }
        public bool? PackageOffer { get; set; }
        public bool? PackageEnabled { get; set; }
        public int? Quantity { get; set; }
        public virtual Categories Categ { get; set; }
        public virtual Menu Menu { get; set; }
      //  public virtual OrderPackage OrderPackage { get; set; }
        public virtual Sections Section { get; set; }
        public virtual ICollection<IngPackageQuantity> IngPackageQuantity { get; set; }
        public virtual ICollection<PackageItem> PackageItem { get; set; }
       
    }
}
