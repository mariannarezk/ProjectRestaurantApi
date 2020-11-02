using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurantApi.Models;

namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public SectionsController(DatabaseContext context)
        {

            this._context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {


            var sections = _context.Sections.ToList();

            return Ok(sections);
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] Sections c)
        {


            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));

        }

        [HttpPost]
        [Route("[action]")]
        public int Edit([FromBody] Sections m)
        {

            _context.Update(m);
            _context.SaveChanges();
            return 1;
        }
        [HttpPost]
        [Route("[action]")]
        public int Delete(Sections m)
        {
            _context.Remove(m);
            _context.SaveChanges();
            return 1;
        }
    }
}
