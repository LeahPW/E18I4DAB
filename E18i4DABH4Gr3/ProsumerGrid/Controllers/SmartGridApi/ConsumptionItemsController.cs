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
using ProsumerGrid.Models.SmartGrid;

namespace ProsumerGrid.Controllers.SmartGridApi
{
    public class ConsumptionItemsController : ApiController
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        // GET: api/ConsumptionDevices
        public IQueryable<ConsumptionDeviceDTO> GetConsumptionItems()
        {
            var conitems = from b in db.ConsumptionDevices
                select new ConsumptionDeviceDTO()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Consumption = b.Consumption
                };
            return conitems;

            //old code
            //return db.ConsumptionDevices;
        }

        // GET: api/ConsumptionDevices/5
        [ResponseType(typeof(ConsumptionDevice))]
        public async Task<IHttpActionResult> GetConsumptionItem(int id)
        {
            var conitem = await db.ConsumptionDevices.Select(b =>
                new ConsumptionDeviceDTO()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Consumption = b.Consumption
                }).SingleOrDefaultAsync(b => b.Id == id);

            if (conitem == null)
            {
                return NotFound();
            }

            return Ok(conitem);
            //old code
            //ConsumptionDevice consumptionDevice = await db.ConsumptionDevices.FindAsync(id);
            //if (consumptionDevice == null)
            //{
            //    return NotFound();
            //}

            //return Ok(consumptionDevice);
        }

        // PUT: api/ConsumptionDevices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConsumptionItem(int id, ConsumptionDevice consumptionDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consumptionDevice.Id)
            {
                return BadRequest();
            }

            db.Entry(consumptionDevice).State = EntityState.Modified;

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

        // POST: api/ConsumptionDevices
        [ResponseType(typeof(ConsumptionDevice))]
        public async Task<IHttpActionResult> PostConsumptionItem(ConsumptionDevice consumptionDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConsumptionDevices.Add(consumptionDevice);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = consumptionDevice.Id }, consumptionDevice);
        }

        // DELETE: api/ConsumptionDevices/5
        [ResponseType(typeof(ConsumptionDevice))]
        public async Task<IHttpActionResult> DeleteConsumptionItem(int id)
        {
            ConsumptionDevice consumptionDevice = await db.ConsumptionDevices.FindAsync(id);
            if (consumptionDevice == null)
            {
                return NotFound();
            }

            db.ConsumptionDevices.Remove(consumptionDevice);
            await db.SaveChangesAsync();

            return Ok(consumptionDevice);
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
            return db.ConsumptionDevices.Count(e => e.Id == id) > 0;
        }
    }
}