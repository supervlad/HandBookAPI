using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swagger.Models;

namespace Swagger
{
    [ApiController]
    [Route("api/[controller]")]
    public class HandBookController : Controller
    {
        MainContext db;

        public HandBookController(MainContext context)
        {
            db = context;
        }

        // GET api/handbook/1
        [HttpGet("{catalogId}")]
        public ActionResult<List<LISTS_38_ITEM>> Get(int? catalogId)
        {
            if (catalogId == null)
                return BadRequest();

            return db.Lists_38_Items.Where(x => x.LIST_ID == catalogId).ToList();
        }

        // POST api/handbook
        [HttpPost]
        public ActionResult<LISTS_38_ITEM> Post(LISTS_38_ITEM item)
        {
            if (item == null)
                return BadRequest();

            db.Lists_38_Items.Add(item);
            db.SaveChangesAsync();
            return item;
        }

        // PUT api/handbook
        [HttpPut]
        public ActionResult<LISTS_38_ITEM> Put(LISTS_38_ITEM item)
        {
            if (item == null)
                return BadRequest();

            bool hasItem = db.Lists_38_Items.Any(x => x.ITEM_KEY == item.ITEM_KEY);

            if (!hasItem)
                return NotFound();

            db.Update(item);
            db.SaveChangesAsync();
            return item;
        }

        // DELETE api/handbook/Confirmer1
        [HttpDelete("{itemId}")]
        public ActionResult<LISTS_38_ITEM> Delete(string itemId)
        {
            if (string.IsNullOrEmpty(itemId))
                return BadRequest();

            LISTS_38_ITEM item = db.Lists_38_Items.FirstOrDefault(x => x.ITEM_KEY == itemId);

            if (item == null)
                return NotFound();

            db.Lists_38_Items.Remove(item);
            db.SaveChangesAsync();
            return item;
        }
    }
}
