using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectRestaurantApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public CategoriesController(DatabaseContext context)
        { 
            this._context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult Get(int menuid)
        {


            var catos = _context.Categories.Where(m => m.MenuId == menuid).ToList();
          
            return Ok(catos);
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] Categories c)
        {


            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));

        }
       
        [HttpPost]
        [Route("[action]")]
        public int Edit([FromBody] Categories m)
        {

            _context.Update(m);
            _context.SaveChanges();
            return 1;
        }
        [HttpPost]
        [Route("[action]")]
        public int Delete(Categories m)
        {
            _context.Remove(m);
            _context.SaveChanges();
            return 1;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetItems(int CategoryId)
        {
            //ana bde red list mn categoryitemviewmodel yale khasson bhyda l catgid
            var allitems = _context.Items.ToList();
            var catsitems = new List<CategoryItemViewModel>();
            foreach(var a in allitems)
            {
                var c = new CategoryItemViewModel();
                c.CategoryId = CategoryId;
                c.ItemId = a.ItemId;
                c.ItemName = a.ItemName;
                int exist=-1;
                if(a.CategId == CategoryId)
                {
                    exist = 0; //it belongs to this category
                }
                else if(a.CategId != null)
                {
                    exist = 1;//it belongs to another category
                }
                else
                {
                    exist = 2;//it doesn't belong to any category
                }
                if(exist == 0)
                {
                    c.IsChoosed = true;
                }
                if(exist == 2)
                {
                    c.IsChoosed = false;
                }
                if (exist != 1)
                {
                    catsitems.Add(c);
                }

            }
            return Ok(catsitems);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveItems(CategoryItemViewModel c)
        {
            var item = _context.Items.Where(f => f.ItemId == c.ItemId).FirstOrDefault();
            if(item.CategId == c.CategoryId)
            {
                if (c.IsChoosed == false)
                {
                    item.CategId = null;
                    _context.SaveChanges();
                }
            }
            if(c.IsChoosed == true)
            {
                item.CategId = c.CategoryId;
                _context.SaveChanges();
            }
            return Ok(item);
        }
    }
}
