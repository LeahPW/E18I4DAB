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
    public class ProsumersController : ApiController
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        // GET: api/Prosumers
        public IQueryable<Prosumer> GetProsumers()
        {
            return db.Prosumers;
        }

        // GET: api/Prosumers/5
        [ResponseType(typeof(Prosumer))]
        public async Task<IHttpActionResult> GetProsumer(int id)
        {
            Prosumer prosumer = await db.Prosumers.FindAsync(id);
            if (prosumer == null)
            {
                return NotFound();
            }

            return Ok(prosumer);
        }

        // PUT: api/Prosumers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProsumer(int id, Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prosumer.ProsumerId)
            {
                return BadRequest();
            }

            db.Entry(prosumer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProsumerExists(id))
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

        // POST: api/Prosumers
        [ResponseType(typeof(Prosumer))]
        public async Task<IHttpActionResult> PostProsumer(Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prosumers.Add(prosumer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = prosumer.ProsumerId }, prosumer);
        }

        // DELETE: api/Prosumers/5
        [ResponseType(typeof(Prosumer))]
        public async Task<IHttpActionResult> DeleteProsumer(int id)
        {
            Prosumer prosumer = await db.Prosumers.FindAsync(id);
            if (prosumer == null)
            {
                return NotFound();
            }

            db.Prosumers.Remove(prosumer);
            await db.SaveChangesAsync();

            return Ok(prosumer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProsumerExists(int id)
        {
            return db.Prosumers.Count(e => e.ProsumerId == id) > 0;
        }
    }
}