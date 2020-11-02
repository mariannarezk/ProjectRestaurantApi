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
    public class AllergensController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public AllergensController(DatabaseContext context)
        {

            this._context = context;
        }

        [HttpGet]
        [Route("[action]")]

        public IActionResult Get()
        {
            var allergens = _context.Allergens.ToList();
            return Ok(allergens);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllAllergens(int itemid)//this function is for get the not choosed allergens
        {
            var allalergens = _context.Allergens.ToList();
            var choosedallg = _context.AllergenItems.Where(i => i.ItemId == itemid).ToList();
            var listallrg = new List<Allergens>();
            foreach (var a in allalergens)
            {
                int exist = 0;
                foreach (var aa in choosedallg)
                {
                    if (aa.AllergenId == a.AllergenId)
                    {
                        exist = 1;
                    }
                }
                if (exist == 0)
                {
                    listallrg.Add(a);
                }
            }


            return Ok(listallrg);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetChoosedAllergens(int itemid)//this function is for get the not choosed allergens
        {
            var allalergens = _context.Allergens.ToList();
            var choosedallg = _context.AllergenItems.Where(i => i.ItemId == itemid).ToList();
            var listallrg = new List<Allergens>();
            foreach (var a in allalergens)
            {
                int exist = 0;
                foreach (var aa in choosedallg)
                {
                    if (aa.AllergenId == a.AllergenId)
                    {
                        exist = 1;
                    }
                }
                if (exist == 1)
                {
                    listallrg.Add(a);
                }
            }


            return Ok(listallrg);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult ChooseAllergen(AllergenItem allergenItem)
        {
            _context.Add(allergenItem);
            _context.SaveChanges();
            return Ok(allergenItem);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult DeleteChoosedAllergen(int allergenId,int itemid)
        {
            var i = _context.AllergenItems.Where(f => f.AllergenId == allergenId).Where(s => s.ItemId == itemid).First();
            _context.Remove(i);
            _context.SaveChanges();
            return Ok(i);
        }
    }
}
