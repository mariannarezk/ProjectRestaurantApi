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
    public class EnsembleAddOnsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public EnsembleAddOnsController(DatabaseContext context)
        {

            this._context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult Get(int menuid)
        {


            var e = _context.EnsembleAddOns.Where(m=>m.MenuId == menuid).ToList();

            return Ok(e);
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] EnsembleAddOns c)
        {
            
            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Get));

        }

        [HttpPost]
        [Route("[action]")]
        public int Edit([FromBody] EnsembleAddOns m)
        {

            _context.Update(m);
            _context.SaveChanges();
            return 1;
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Delete(int ensembleid)
        {
            var m = _context.EnsembleAddOns.Where(k => k.EnsembleAddonId == ensembleid).FirstOrDefault();
            _context.Remove(m);
            _context.SaveChanges();
            var list = _context.EnsembleOptionalRlt.Where(f => f.EnsembleId == ensembleid).ToList();
            foreach(var l in list)
            {
                _context.Remove(l);
                _context.SaveChanges();
            }
            return Ok();
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAddOnes(int ensembleid)
        {
         

         var alls = new List<EnsembleAddonsViewModel>();
            var addones = _context.AddOnes.ToList();
            foreach(var a in addones)
            {
                var j = new EnsembleAddonsViewModel();

                j.addonid = a.AddOnesId;
                    j.addonName = a.AddOnesName;
                j.ensembleid = ensembleid;
                
                var i = _context.EnsembleOptionalRlt.Where(f => f.AddOnId == a.AddOnesId).Where(k => k.EnsembleId == ensembleid).ToList();
               
                if (i.Count() == 0)
                {
                    j.choosed = false;
                }
                else
                {
                    var f = _context.EnsembleOptionalRlt.Where(f => f.AddOnId == a.AddOnesId).Where(k => k.EnsembleId == ensembleid).FirstOrDefault();
                    j.price = f.Price;
                    j.choosed = true;
                }
                alls.Add(j);
            }
            return Ok(alls);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveAddones(EnsembleAddonsViewModel e)
        {
            var rlt = _context.EnsembleOptionalRlt.Where(r => r.AddOnId == e.addonid).Where(k=>k.EnsembleId == e.ensembleid).FirstOrDefault();
           if(e.choosed == false)
            {
                if(rlt != null)
                {
                    _context.Remove(rlt);
                    _context.SaveChanges();

                }
            }
            if (e.choosed == true)
            {
                if(rlt == null)
                {
                    var c = new EnsembleOptionalRlt();
                    c.AddOnId = e.addonid;
                    c.EnsembleId = e.ensembleid;
                    c.Price = e.price;
                    _context.Add(c);
                    _context.SaveChanges();
                }
                else
                {
                    rlt.Price = e.price;
                    _context.Update(rlt);
                    _context.SaveChanges();
                }
            }
            return Ok(e);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult getEnsemblesVM(int itemid,int menuid)
        {
            var allensembles = _context.EnsembleAddOns.Where(m=>m.MenuId == menuid).ToList();
            var ens = new List<EnsembleItemViewModel>();
            foreach(var a in allensembles)
            {
                var e = new EnsembleItemViewModel();
                e.EnsembleId = a.EnsembleAddonId;
                e.ItemId = itemid;
                e.EnsembleName = a.EnsembleName;
                var exist = _context.OptionalAddonItems.Where(f => f.EnsembleId == a.EnsembleAddonId).Where(q => q.ItemId == itemid).FirstOrDefault();
                if(exist == null)
                {
                    e.IsChoosed = false;
                }
                else
                {
                    e.IsChoosed = true;
                }
                ens.Add(e);
               
            }
            return Ok(ens);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult saveEnsembleItem(EnsembleItemViewModel e)
        {
            var a = _context.OptionalAddonItems.Where(f => f.EnsembleId == e.EnsembleId).Where(q => q.ItemId == e.ItemId).FirstOrDefault();

            if (e.IsChoosed == true)
            {
                if(a == null)
                {
                    var n = new OptionalAddonItem();
                    n.ItemId = e.ItemId;
                    n.EnsembleId = e.EnsembleId;
                    _context.Add(n);
                    _context.SaveChanges();
                }
                
            }
            else
            {
                if (a != null)
                {
                    _context.Remove(a);
                    _context.SaveChanges();
                }
            }


            return Ok(e);
        }

    }
}
