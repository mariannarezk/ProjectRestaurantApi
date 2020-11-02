using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectRestaurantApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<RestaurantController> _logger;
        public RestaurantController(DatabaseContext context, ILogger<RestaurantController> logger)
        {
            this._logger = logger;
            this._context = context;
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
        public IActionResult CreateRest(Restaurant r)
        {

            _context.Add(r);
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
