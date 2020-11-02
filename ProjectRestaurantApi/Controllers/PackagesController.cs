using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectRestaurantApi.Models;

namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class PackagesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public PackagesController(DatabaseContext context)
        {

            this._context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult Get(int menuid)
        {
            var packages = _context.Packages.Where(m=>m.Menu_Id == menuid).ToList();

            return Ok(packages);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody] Packages c)
        {


            _context.Add(c);
            _context.SaveChanges();
            return Ok(c);

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Edit([FromBody] Packages c)
        {


            _context.Update(c);
            _context.SaveChanges();
            return Ok(c);

        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult getallitems(int packageid)
        {
     

            var allitems = _context.Items.ToList();
            var itemspack = _context.itempackages.Where(f => f.PackageId == packageid).ToList();
            var items = new List<Items>();
            foreach(var i in allitems)
            {
                int exist = 0;
                foreach(var j in itemspack)
                {
                    if(i.ItemId == j.ItemId)
                    {
                        exist = 1;
                    }
                }
                if(exist == 0)
                {
                    items.Add(i);
                }
            }
            return Ok(items);
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult getchoosenitems(int packageid)
        {
            var allitems = _context.Items.ToList();
            var itemspack = _context.itempackages.Where(f => f.PackageId == packageid).ToList();
            var items = new List<Items>();
            foreach (var i in allitems)
            {
                int exist = 0;
                foreach (var j in itemspack)
                {
                    if (i.ItemId == j.ItemId)
                    {
                        exist = 1;
                    }
                }
                if (exist!=0)
                {
                    items.Add(i);
                }
            }
            return Ok(items);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult ChooseItem(Itempackage i)
        {

            _context.Add(i);
            _context.SaveChanges();
            return Ok(i);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetPackagesItemsVM(int packid,int menuid) {
            var allitems = _context.Items.Where(f => f.Menu_Id == menuid).ToList();
            var items = new List<PackageItemViewModel>();
            foreach(var a in allitems)
            {
                var p = new PackageItemViewModel();
                p.PackageId = packid;
                p.ItemId = a.ItemId;
                p.ItemName = a.ItemName;
                var exist = _context.itempackages.Where(f => f.ItemId == a.ItemId).Where(s => s.PackageId == packid).FirstOrDefault();
                if(exist == null)
                {
                    p.IsChoosed = false;
                }
                else
                {
                    p.IsChoosed = true;
                    p.Quantity = exist.ItemQuantity;
                }
                items.Add(p);
            }

            return Ok(items);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult saveItemPackage(PackageItemViewModel p)
        {
            var i = _context.itempackages.Where(f => f.PackageId == p.PackageId).Where(k => k.ItemId == p.ItemId).FirstOrDefault();

            if (p.IsChoosed == true)
            {
                if(i == null)
                {
                    var n = new Itempackage();
                    n.ItemId = p.ItemId;
                    n.PackageId = p.PackageId;
                    n.ItemQuantity = p.Quantity;
                    _context.Add(n);
                    _context.SaveChanges();
                }
                else
                {
                    i.ItemQuantity = p.Quantity;
                    _context.Update(i);
                    _context.SaveChanges();
                }
            }
            else
            {
                if (i != null)
                {
                    _context.Remove(i);
                    _context.SaveChanges();
                }
            }
            return Ok();
        }
    }
}
