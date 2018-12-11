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
    public class ConsumptionItemsController : ApiController
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        // GET: api/ConsumptionItems
        public IQueryable<ConsumptionItemDTO> GetConsumptionItems()
        {
            var conitems = from b in db.ConsumptionItems
                select new ConsumptionItemDTO()
                {
                    ConItemId = b.ConItemId,
                    Name = b.Name,
                    ProsumerAddress = b.Prosumer.Address,
                    ProsumerType = b.Prosumer.Type
                };
            return conitems;

            //old code
            //return db.ConsumptionItems;
        }

        // GET: api/ConsumptionItems/5
        [ResponseType(typeof(ConsumptionItem))]
        public async Task<IHttpActionResult> GetConsumptionItem(int id)
        {
            var conitem = await db.ConsumptionItems.Include(b => b.Prosumer).Select(b =>
                new ConsumptionItemDTO()
                {
                    ConItemId = b.ConItemId,
                    Name = b.Name,
                    ProsumerAddress = b.Prosumer.Address,
                    ProsumerType = b.Prosumer.Type
                }).SingleOrDefaultAsync(b => b.ConItemId == id);

            if (conitem == null)
            {
                return NotFound();
            }

            return Ok(conitem);
            //old code
            //ConsumptionItem consumptionItem = await db.ConsumptionItems.FindAsync(id);
            //if (consumptionItem == null)
            //{
            //    return NotFound();
            //}

            //return Ok(consumptionItem);
        }

        // PUT: api/ConsumptionItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConsumptionItem(int id, ConsumptionItem consumptionItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consumptionItem.ConItemId)
            {
                return BadRequest();
            }

            db.Entry(consumptionItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumptionItemExists(id))
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

        // POST: api/ConsumptionItems
        [ResponseType(typeof(ConsumptionItem))]
        public async Task<IHttpActionResult> PostConsumptionItem(ConsumptionItem consumptionItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConsumptionItems.Add(consumptionItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = consumptionItem.ConItemId }, consumptionItem);
        }

        // DELETE: api/ConsumptionItems/5
        [ResponseType(typeof(ConsumptionItem))]
        public async Task<IHttpActionResult> DeleteConsumptionItem(int id)
        {
            ConsumptionItem consumptionItem = await db.ConsumptionItems.FindAsync(id);
            if (consumptionItem == null)
            {
                return NotFound();
            }

            db.ConsumptionItems.Remove(consumptionItem);
            await db.SaveChangesAsync();

            return Ok(consumptionItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsumptionItemExists(int id)
        {
            return db.ConsumptionItems.Count(e => e.ConItemId == id) > 0;
        }
    }
}