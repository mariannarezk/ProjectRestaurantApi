using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectRestaurantApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdminController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public SuperAdminController(DatabaseContext context)
        {
            this._context = context;
        }
        // GET: api/<SuperAdminController>
        [HttpGet]
        public IActionResult Get()
        {
            var r = _context.Restaurant.Where(c => c.RestaurantActive == 0).ToList();
            List<RestaurantManagerBindingModel> restos = new List<RestaurantManagerBindingModel>();
            foreach(var res in r)
            {
                RestaurantManagerBindingModel resman = new RestaurantManagerBindingModel();
                resman.RestaurantId = res.RestaurantId;
                resman.RestaurantLogo = res.RestaurantLogo;
                resman.RestaurantName = res.RestaurantName;
                resman.RestPhoneNumber = res.RestPhoneNumber;
                var m = _context.ApplicationUsers.Where(x => x.RestaurantId == res.RestaurantId).FirstOrDefault();
                if (m != null)
                {
                    resman.manageremail = m.Email;
                    resman.managerfullname = m.FullName;
                    restos.Add(resman);
                }
                
            }
            return Ok(restos);
        }

        // GET api/<SuperAdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SuperAdminController>
        [HttpPost]
        [Route("Accept")]
        public IActionResult Accept(int restid)
        {
            var x = _context.Restaurant.Where(q => q.RestaurantId == restid).FirstOrDefault();
            x.RestaurantActive = 1;
            _context.Update(x);
            _context.SaveChanges();
            return Ok();
        }
        
        // POST api/<SuperAdminController>
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int restid)
        {
            var x = _context.Restaurant.Where(q => q.RestaurantId == restid).FirstOrDefault();
            x.RestaurantActive = -1;
            _context.Update(x);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<SuperAdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

    }
}
