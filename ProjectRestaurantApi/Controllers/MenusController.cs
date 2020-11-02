using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurantApi.Models;

namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public MenusController(DatabaseContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult GetM()
        {
            var menus = _context.Menus.ToList();
            // var menus = "ok";
            return Ok(menus);
        }
        [HttpPost]

        public IActionResult CreateM(Menu m)
        {


            _context.Add(m);
            _context.SaveChanges();
            return RedirectToAction(nameof(GetM));

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult save([FromBody] Menu m)
        {


            _context.Add(m);
            _context.SaveChanges();
            return RedirectToAction(nameof(GetM));

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Edit(Menu m)
        {

            _context.Update(m);
            _context.SaveChanges();
            return Ok(m);
        }
        [HttpPost]
        [Route("[action]")]
        public int Delete(Menu m)
        {
            _context.Remove(m);
            _context.SaveChanges();
            return 1;
        }
    }
}
