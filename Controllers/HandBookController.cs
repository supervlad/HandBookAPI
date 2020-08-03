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

            if (!db.Lists_38_Catalogs.Any() || !db.Lists_38_Items.Any())
            {
                db.Lists_38_Catalogs.Add(new LISTS_38_CATALOG { TASK_ID = 2345, LIST_NAME = "Cогласующие", LIST_DESCRIPTION = "Типы согласующих" });
                db.Lists_38_Catalogs.Add(new LISTS_38_CATALOG { TASK_ID = 2897, LIST_NAME = "Cогласование", LIST_DESCRIPTION = "Типы согласования" });
                db.Lists_38_Items.Add(new LISTS_38_ITEM { LIST_ID = 1, ITEM_KEY = "Confirmer1", ITEM_VALUE = "Директор" });
                db.Lists_38_Items.Add(new LISTS_38_ITEM { LIST_ID = 1, ITEM_KEY = "Confirmer2", ITEM_VALUE = "Сотрудник СБ" });
                db.Lists_38_Items.Add(new LISTS_38_ITEM { LIST_ID = 2, ITEM_KEY = "Agreement1", ITEM_VALUE = "Последовательное" });
                db.Lists_38_Items.Add(new LISTS_38_ITEM { LIST_ID = 2, ITEM_KEY = "Agreement2", ITEM_VALUE = "Параллельное" });
                db.SaveChanges();
            }
        }

        // GET: api/handbook
        [HttpGet]
        public ActionResult<List<LISTS_38_ITEM>> Get()
        {
            List<LISTS_38_ITEM> itemList = db.Lists_38_Items.ToList();

            if (itemList == null)
                return NotFound();

            return itemList;
        }

        // GET api/handbook/1
        [HttpGet("{catalogId}")]
        public ActionResult<List<LISTS_38_ITEM>> Get(int catalogId)
        {
            List<LISTS_38_ITEM> itemList = db.Lists_38_Items.Where(x => x.LIST_ID == catalogId).ToList();

            if (itemList == null)
                return NotFound();

            return itemList;
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
            LISTS_38_ITEM item = db.Lists_38_Items.FirstOrDefault(x => x.ITEM_KEY == itemId);

            if (item == null)
                return NotFound();

            db.Lists_38_Items.Remove(item);
            db.SaveChangesAsync();
            return item;
        }
    }
}
