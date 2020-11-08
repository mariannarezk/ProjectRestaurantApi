using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectRestaurantApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly DatabaseContext _context;
        private readonly ILogger<RestaurantController> _logger;
        public RestaurantController(DatabaseContext context, ILogger<RestaurantController> logger, UserManager<ApplicationUser> userManager)
        {
            this._logger = logger;
            this._context = context;
            this._userManager = userManager;
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult GetRest()
        {
            var restos= _context.Restaurant.ToList();
            return Ok(restos);

        }
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateRest(RestaurantManagerBindingModel r)
        {
            Restaurant rest = new Restaurant();
            rest.RestaurantLogo = r.RestaurantLogo;
            rest.RestaurantName = r.RestaurantName;
            rest.RestNotes = r.RestNotes;
            rest.RestPhoneNumber = r.RestPhoneNumber;
            rest.RestaurantActive = 0;
            _context.Add(rest);
            _context.SaveChanges();
            ApplicationUser a = _context.ApplicationUsers.Where(c => c.Id == r.userid).FirstOrDefault();
            a.RestaurantId = rest.RestaurantId;
            
            
            _context.Update(a);
            _context.SaveChanges();
            //return RedirectToAction(nameof(GetM));
            return Ok(r);
        }
        
            //[HttpGet]
        //public IActionResult GetBanch(int restid)
        //{
            
        //    var branches = _context.RestaurantBranch.Where(b=>b.RestaurantId == restid).ToList();
        //    // var menus = "ok";
        //    return Ok(branches);
        //}
    }
}
