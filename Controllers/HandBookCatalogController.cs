using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swagger.Models;

namespace Swagger
{
    [ApiController]
    [Route("api/[controller]")]
    public class HandBookCatalogController : Controller
    {
        MainContext db;

        public HandBookCatalogController(MainContext context)
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

        // GET api/handbookcatalog
        [HttpGet]
        public ActionResult<List<LISTS_38_CATALOG>> Get()
        {
            List<LISTS_38_CATALOG> catalogList = db.Lists_38_Catalogs.ToList();

            if (catalogList == null)
                return NotFound();

            return catalogList;
        }

        // POST api/handbookcatalog
        [HttpPost]
        public ActionResult<LISTS_38_CATALOG> Post(LISTS_38_CATALOG item)
        {
            if (item == null)
                return BadRequest();

            db.Lists_38_Catalogs.Add(item);
            db.SaveChangesAsync();
            return item;
        }

        // PUT api/handbookcatalog
        [HttpPut]
        public ActionResult<LISTS_38_CATALOG> Put(LISTS_38_CATALOG item)
        {
            if (item == null)
                return BadRequest();

            bool hasItem = db.Lists_38_Catalogs.Any(x => x.LIST_ID == item.LIST_ID);

            if (!hasItem)
                return NotFound();

            db.Update(item);
            db.SaveChangesAsync();
            return item;
        }

        // DELETE api/handbookcatalog/1
        [HttpDelete("{itemId}")]
        public ActionResult<LISTS_38_CATALOG> Delete(int itemId)
        {
            if (itemId == 0)
                return BadRequest();

            LISTS_38_CATALOG item = db.Lists_38_Catalogs.FirstOrDefault(x => x.LIST_ID == itemId);

            if (item == null)
                return NotFound();

            db.Lists_38_Catalogs.Remove(item);
            db.SaveChangesAsync();
            return item;
        }
    }
}
