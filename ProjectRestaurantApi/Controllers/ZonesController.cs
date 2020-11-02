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
    public class ZonesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<ZonesController> _logger;
        public ZonesController(DatabaseContext context, ILogger<ZonesController> logger)
        {
            this._logger = logger;
            this._context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Get(int branchid)
        {
            var zones = _context.Zones.Where(b => b.BranchId ==  branchid).ToList();
            
            return Ok(zones);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] Zones c)
        {


            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Edit([FromBody] Zones m)
        {
            _context.Update(m);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));
        }
    }
}
