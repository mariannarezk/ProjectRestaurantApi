using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurantApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
