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
using ProsumerGrid.Models.Prosumer;
using ProsumerGrid.Models.SmartGrid;

namespace ProsumerGrid.Controllers.SmartGridApi
{
    public class ProductionItemsController : ApiController
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        // GET: api/ProductionDevices
        public IQueryable<ProductionDeviceDTO> GetProductionItems()
        {
            var proitems = from b in db.ProductionDevices
                select new ProductionDeviceDTO()
                {
                    ProDeviceId = b.ProDeviceId,
                    Name = b.Name,
                    Production = b.Production,
                    ProsumerAddress = b.Prosumer.Address,
                    ProsumerType = b.Prosumer.Type
                };
            return proitems;

            //old code
            //return db.ProductionDevices;
        }

        // GET: api/ProductionDevices/5
        [ResponseType(typeof(ProductionDevice))]
        public async Task<IHttpActionResult> GetProductionItem(int id)
        {
            var proitem = await db.ProductionDevices.Include(b => b.Prosumer).Select(b =>
                new ProductionDeviceDTO()
                {
                    ProDeviceId = b.ProDeviceId,
                    Name = b.Name,
                    Production = b.Production,
                    ProsumerAddress = b.Prosumer.Address,
                    ProsumerType = b.Prosumer.Type
                }).SingleOrDefaultAsync(b => b.ProDeviceId == id);

            if (proitem == null)
            {
                return NotFound();
            }

            return Ok(proitem);

            //old code
            //ProductionDevice productionDevice = await db.ProductionDevices.FindAsync(id);
            //if (productionDevice == null)
            //{
            //    return NotFound();
            //}

            //return Ok(productionDevice);
        }

        // PUT: api/ProductionDevices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductionItem(int id, ProductionDevice productionDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productionDevice.ProDeviceId)
            {
                return BadRequest();
            }

            db.Entry(productionDevice).State = EntityState.Modified;

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

        // POST: api/ProductionDevices
        [ResponseType(typeof(ProductionDevice))]
        public async Task<IHttpActionResult> PostProductionItem(ProductionDevice productionDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductionDevices.Add(productionDevice);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productionDevice.ProDeviceId }, productionDevice);
        }

        // DELETE: api/ProductionDevices/5
        [ResponseType(typeof(ProductionDevice))]
        public async Task<IHttpActionResult> DeleteProductionItem(int id)
        {
            ProductionDevice productionDevice = await db.ProductionDevices.FindAsync(id);
            if (productionDevice == null)
            {
                return NotFound();
            }

            db.ProductionDevices.Remove(productionDevice);
            await db.SaveChangesAsync();

            return Ok(productionDevice);
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
            return db.ProductionDevices.Count(e => e.ProDeviceId == id) > 0;
        }
    }
}