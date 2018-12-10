using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProsumerGrid.Models;

namespace ProsumerGrid.Controllers
{
    public class ProductionItemsController : ApiController
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        // GET: api/ProductionItems
        public IQueryable<ProductionItem> GetProductionItems()
        {
            return db.ProductionItems;
        }

        // GET: api/ProductionItems/5
        [ResponseType(typeof(ProductionItem))]
        public async Task<IHttpActionResult> GetProductionItem(int id)
        {
            ProductionItem productionItem = await db.ProductionItems.FindAsync(id);
            if (productionItem == null)
            {
                return NotFound();
            }

            return Ok(productionItem);
        }

        // PUT: api/ProductionItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductionItem(int id, ProductionItem productionItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productionItem.ProItemId)
            {
                return BadRequest();
            }

            db.Entry(productionItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductionItems
        [ResponseType(typeof(ProductionItem))]
        public async Task<IHttpActionResult> PostProductionItem(ProductionItem productionItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductionItems.Add(productionItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productionItem.ProItemId }, productionItem);
        }

        // DELETE: api/ProductionItems/5
        [ResponseType(typeof(ProductionItem))]
        public async Task<IHttpActionResult> DeleteProductionItem(int id)
        {
            ProductionItem productionItem = await db.ProductionItems.FindAsync(id);
            if (productionItem == null)
            {
                return NotFound();
            }

            db.ProductionItems.Remove(productionItem);
            await db.SaveChangesAsync();

            return Ok(productionItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductionItemExists(int id)
        {
            return db.ProductionItems.Count(e => e.ProItemId == id) > 0;
        }
    }
}