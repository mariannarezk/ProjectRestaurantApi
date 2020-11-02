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
    public class AddOnesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public AddOnesController(DatabaseContext context)
        {

            this._context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {


            var ingredients = _context.AddOnes.ToList();

            return Ok(ingredients);
        }
       /* [HttpGet]
        [Route("[action]")]
        public IActionResult GetAddOnes(int itemid)//this fct for existed obligatory add ons
        {
            var addonesids =_context.ObligAddOnsItems.Where(i=>i.ItemId == itemid).ToList();
            var addones = new List<ObligAdonItemViewModel>();
            foreach(var o in addonesids)
            {
                var a = _context.AddOnes.Where(m => m.AddOnesId == o.AddOnsId).FirstOrDefault();
                var i = new ObligAdonItemViewModel();
                i.AddOnName = a.AddOnesName;
                i.Quantity = o.Quantity;
                i.ObligId = o.ObligId;
                i.AddOnsId = a.AddOnesId;
                i.ItemId = o.ItemId;
                i.Price = o.Price;
                addones.Add(i);
            }
            return Ok(addones);
        }
       */
       [HttpGet]
       [Route("[action]")]
       public IActionResult GetObligAddonsItemVM(int itemid) {
            var alladones = _context.AddOnes.ToList();
            var addonesvm = new List<ObligAdonItemViewModel>();
            foreach(var a in alladones)
            {
                var o = new ObligAdonItemViewModel();
                o.AddonId = a.AddOnesId;
                o.ItemId = itemid;
                o.AddonName = a.AddOnesName;
              
                var exist = _context.ObligAddOnsItems.Where(f => f.AddOnsId == a.AddOnesId).Where(k => k.ItemId == itemid).FirstOrDefault();
                if(exist == null)
                {
                    o.IsChoosed = false;
                }
                else
                {
                    o.IsChoosed = true;
                    o.Quantity = exist.Quantity;
                    o.Price = exist.Price;
                }
                addonesvm.Add(o);
            }
            return Ok(addonesvm);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveObligAddonsItemsVM(ObligAdonItemViewModel o)
        {
            if(o.IsChoosed == true)
            {
                var k = _context.ObligAddOnsItems.Where(m => m.ItemId == o.ItemId).Where(f => f.AddOnsId == o.AddonId).FirstOrDefault();
                if (k == null)
                {
                    var n = new ObligAddOnsItems();
                    n.AddOnsId = o.AddonId;
                    n.ItemId = o.ItemId;
                    n.Price = o.Price;
                    n.Quantity = o.Quantity;
                    _context.ObligAddOnsItems.Add(n);
                    _context.SaveChanges();
                }
                else
                {
                    k.Price = o.Price;
                    k.Quantity = o.Quantity;
                    _context.ObligAddOnsItems.Update(k);
                    _context.SaveChanges();
                }
            }
            else
            {
                var k = _context.ObligAddOnsItems.Where(m => m.ItemId == o.ItemId).Where(f => f.AddOnsId == o.AddonId).FirstOrDefault();
                if (k !=null)
                {
                    _context.ObligAddOnsItems.Remove(k);
                    _context.SaveChanges();
                }
            }
            return Ok(o);
        }
       



        /*
           {
        "itemId": 1,
        "addonId": 5,
        "addonName": "Mtabal Batenjen",
        "quantity": 0,
        "price": "3$",
        "isChoosed": false
    }
         
         */
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetExistedOptional(int ensembleid)//this fct for get existed optional add ons
        {
            var addonesids = _context.EnsembleOptionalRlt.Where(i => i.EnsembleId == ensembleid).ToList();
            var addones = new List<OptionalAddonItemViewModel>();
            foreach (var o in addonesids)
            {
                var a = _context.AddOnes.Where(m => m.AddOnesId == o.AddOnId).FirstOrDefault();
                var i = new OptionalAddonItemViewModel();

                i.RltId = o.RltId;
                i.EnsemleId = o.EnsembleId;
                i.AddOnId = a.AddOnesId;
                i.AddoneName = a.AddOnesName;
                i.Quantity = o.Quantity;
                i.Price = o.Price;
                i.Size = a.AddOnesSize;

                
                addones.Add(i);
            }
            return Ok(addones);
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAddOnesSupp(int itemid)//this fct for optional addons
        {
            var addones = _context.AddOnes.ToList();
            var listaddones = new List<AddOnes>();
            foreach(var a in addones)
            {
                int exist = 0;
                var rlt = _context.ObligAddOnsItems.Where(c => c.AddOnsId == a.AddOnesId).ToList();
                foreach(var r in rlt)
                {
                    if(r.ItemId == itemid)
                    {
                        exist = 1;
                    }
                }
                if (exist == 0)
                {
                    
                    listaddones.Add(a); 
                }
            }
            return Ok(listaddones);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult getaddonesEnsemble(int ensembleid)
        {
            var addones = _context.AddOnes.ToList();
           var listaddones = new List<AddOnes>();
            foreach (var a in addones)
            {
                int exist = 0;
                var rlt = _context.EnsembleOptionalRlt.Where(e => e.EnsembleId == ensembleid).ToList();
               
                
                    foreach (var r in rlt)
                    {
                        if (r.AddOnId == a.AddOnesId)
                        {
                            exist = 1;
                        }
                    }
               
                if(exist == 0)
                {
                    listaddones.Add(a);
                }
            }
            return Ok(listaddones);
        }
       
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] AddOnes c)
        {


            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateRltOptional( EnsembleOptionalRlt c)
        {


            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Createrlt( ObligAddOnsItems c)
        {


            _context.Add(c);
            _context.SaveChanges();
            return Ok(c);

        }
        [HttpPost]
        [Route("[action]")]
        public int Edit([FromBody] AddOnes m)
        {

            _context.Update(m);
            _context.SaveChanges();
            return 1;
        }
        [HttpPost]
        [Route("[action]")]
        public int Editrlt( ObligAddOnsItems m)
        {
            _context.Update(m);
            _context.SaveChanges();
            return 1;
        }
        [HttpPost]
        [Route("[action]")]
        public int Delete(AddOnes m)
        {
            _context.Remove(m);
            _context.SaveChanges();
            return 1;
        }
    }
}
