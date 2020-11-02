using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ProjectRestaurantApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IWebHostEnvironment hostEnvironment;

        private readonly DatabaseContext _context;
        public ItemsController(DatabaseContext context, IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;

            this._context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult Get(int categid)
        {


            var items = _context.Items.Where(m=>m.CategId == categid).ToList();
           // var items2 = _context.Items.ToList();
            return Ok(items);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetItemsMenu(int menuid)
        {


            var items = _context.Items.Where(m => m.Menu_Id == menuid).ToList();
            return Ok(items);
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult GetName(int itemid)
        {
            var itemname = _context.Items.Where(m => m.ItemId == itemid).FirstOrDefault();
            return Ok(itemname);
        }
        [HttpPost,DisableRequestSizeLimit]
        [Route("[action]")]
        public IActionResult Create([FromBody] Items c)
        {
          /*  try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }


            */

           /* string wwwRootPath = hostEnvironment.WebRootPath;
              string fileName = Path.GetFileNameWithoutExtension(c.ImageFile.FileName);
              string extension = Path.GetExtension(c.ImageFile.FileName);
              c.ItemImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
              string path = Path.Combine(wwwRootPath + "/Image/", fileName);
              using (var fileStream = new FileStream(path, FileMode.Create))
              {
                   c.ImageFile.CopyToAsync(fileStream);
              }*/
            _context.Add(c);
            _context.SaveChanges();
            return Ok(c);

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Edit([FromBody] Items m)
        {

            _context.Update(m);
            _context.SaveChanges();
            return Ok(m);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult ChooseIngr(IngredientItem i)
        {
            
            _context.Add(i);
            _context.SaveChanges();
            return Ok(i);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetIngrs(int itemid,int branchid)
        {
            var allingrs = _context.Ingredients.Where(b=>b.BranchId == branchid).ToList();
            var ingrs = new List<ItemIngredientViewModel>();
         foreach(var a in allingrs)
            {
                var i = new ItemIngredientViewModel();
                i.ItemId = itemid;
                i.IngredientId = a.IngredientId;
                i.IngredientName = a.IngredientName;
                var exist = _context.ingredientItems.Where(l => l.ItemId == itemid).Where(q => q.IngredientId == a.IngredientId).FirstOrDefault();
                if(exist == null)
                {
                    i.IsChoosed = false;
                    
                }
                else
                {
                    i.IsChoosed = true;
                    i.Quantity = exist.Quantity;
                }
                ingrs.Add(i);
            }
            return Ok(ingrs);

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveItemsIngr(ItemIngredientViewModel i)
        {
            if(i.IsChoosed == true)
            {
                var k = _context.ingredientItems.Where(l => l.ItemId == i.ItemId).Where(f => f.IngredientId == i.IngredientId).FirstOrDefault();
                if (k == null)
                {
                    var n = new IngredientItem();
                    n.IngredientId = i.IngredientId;
                    n.ItemId = i.ItemId;
                    n.Quantity = i.Quantity;
                    _context.Add(n);
                    _context.SaveChanges();
                }
                else
                {
                    if(k.Quantity != i.Quantity)
                    {
                        k.Quantity = i.Quantity;
                        _context.Update(k);
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                var k = _context.ingredientItems.Where(l => l.ItemId == i.ItemId).Where(f => f.IngredientId == i.IngredientId).FirstOrDefault();
                if (k != null)
                {
                    _context.Remove(k);
                    _context.SaveChanges();
                }

            }
            return Ok(i);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllergens(int itemid)
        {
            var allAllergens = _context.Allergens.ToList();
            var allergens = new List<AllergenItemViewModel>();
            foreach (var a in allAllergens)
            {
                var i = new AllergenItemViewModel();
                i.ItemId = itemid;
                i.AllergenId = a.AllergenId;
                i.AllergenName = a.AllergenName;
                var exist = _context.AllergenItems.Where(l => l.ItemId == itemid).Where(q => q.AllergenId == a.AllergenId).FirstOrDefault();
                if (exist == null)
                {
                    i.IsChoosed = false;

                }
                else
                {
                    i.IsChoosed = true;
                   
                }
                allergens.Add(i);
            }
            return Ok(allergens);

        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveAllergenItem(AllergenItemViewModel i)
        {
            if (i.IsChoosed == true)
            {
                var k = _context.AllergenItems.Where(l => l.ItemId == i.ItemId).Where(f => f.AllergenId == i.AllergenId).FirstOrDefault();
                if (k == null)
                {
                    var n = new AllergenItem();
                    n.AllergenId = i.AllergenId;
                    n.ItemId = i.ItemId;
                    
                   
                    _context.Add(n);
                    _context.SaveChanges();
                }
                
            }
            else
            {
                var k = _context.AllergenItems.Where(l => l.ItemId == i.ItemId).Where(f => f.AllergenId == i.AllergenId).FirstOrDefault();
                if (k != null)
                {
                    _context.Remove(k);
                    _context.SaveChanges();
                }

            }
            return Ok(i);
        }
    }
}
