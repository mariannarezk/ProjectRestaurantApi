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
    public class IngredientsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public IngredientsController(DatabaseContext context)
        {

            this._context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {


            var ingredients = _context.Ingredients.ToList();

            return Ok(ingredients);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetChoosen(int itemid)
        {
           /*var ingr = _context.IngrItemQuantities.ToList();
           var ingridients = _context.Ingredients.ToList();
            var ingrall = new List<Ingredients>();
            foreach (var i in ingridients)
            {
                // var ingred = _context.Ingredients.Where(m => m.IngredientId == i.IngredientId).FirstOrDefault();
                //ingrall.Add(ingred);
                int exist = 0;
                foreach (var a in ingr)
                {
                    if (a.IngredientId == i.IngredientId)
                    {
                        exist = 1;
                    }
                }
                if (exist != 0)
                {
                    ingrall.Add(i);
                }

            }
           */
            var ingrs = _context.Ingredients.ToList();
           var ingr = _context.ingredientItems.Where(m=>m.ItemId == itemid).ToList();
            var ingridients = _context.Ingredients.ToList();
            var ingrall = new List<Ingredients>();
            foreach (var i in ingridients)
            {
                // var ingred = _context.Ingredients.Where(m => m.IngredientId == i.IngredientId).FirstOrDefault();
                //ingrall.Add(ingred);
                int exist = 0;
                foreach (var a in ingr)
                {
                    if (a.IngredientId == i.IngredientId)
                    {
                        exist = 1;
                    }
                }
                if (exist != 0)
                {
                    ingrall.Add(i);
                }

            }
            return Ok(ingrall);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll(int itemid)
        {
            var ingr = _context.ingredientItems.Where(m => m.ItemId == itemid).ToList();
            var ingridients = _context.Ingredients.ToList();
            var ingrall = new List<Ingredients>();
            foreach(var i in ingridients)
            {
                // var ingred = _context.Ingredients.Where(m => m.IngredientId == i.IngredientId).FirstOrDefault();
                //ingrall.Add(ingred);
                int exist = 0;
                foreach(var a in ingr)
                {
                    if(a.IngredientId == i.IngredientId)
                    {
                        exist = 1;
                    }
                }
                if (exist == 0)
                {
                    ingrall.Add(i);
                }
            
            }
           
            var ingrs = _context.Ingredients.ToList();
            return Ok(ingrall);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] Ingredients c)
        {


            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult ChooseIng([FromBody] IngredientItem c)
        {


            _context.Add(c);
            _context.SaveChanges();
            return Ok(c);

        }
        [HttpPost]
        [Route("[action]")]
        public int Edit([FromBody] Ingredients m)
        {

            _context.Update(m);
            _context.SaveChanges();
            return 1;
        }
        [HttpPost]
        [Route("[action]")]
        public int Delete(Ingredients m)
        {
            _context.Remove(m);
            _context.SaveChanges();
            return 1;
        }
    }
}
