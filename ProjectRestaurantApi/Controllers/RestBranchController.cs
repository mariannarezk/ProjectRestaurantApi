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
    public class RestBranchController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<RestBranchController> _logger;
        public RestBranchController(DatabaseContext context, ILogger<RestBranchController> logger)
        {
            this._logger = logger;
            this._context = context;
        }
        
        [HttpGet]
        [Route("[action]")]
        public IActionResult Get(int restid)
        {

            var branches = _context.RestaurantBranch.Where(b=>b.RestaurantId==restid).ToList();
            // var menus = "ok";
            return Ok(branches);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] RestaurantBranch c)
        {


            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Edit([FromBody] RestaurantBranch m)
        {
            //RestaurantBranch m1 = _context.RestaurantBranch.Where(s => s.BranchId == m.BranchId).FirstOrDefault();
            
            _context.Update(m);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));
        }
    }
}
