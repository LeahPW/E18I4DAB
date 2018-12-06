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
using ProsumerInfo.Models;

namespace ProsumerInfo.Controllers
{
    public class ProsumptionsController : ApiController
    {
        private ProsumerInfoContext db = new ProsumerInfoContext();

        // GET: api/Prosumptions
        public IQueryable<Prosumption> GetProsumptions()
        {
            return db.Prosumptions;
        }

        // GET: api/Prosumptions/5
        [ResponseType(typeof(Prosumption))]
        public async Task<IHttpActionResult> GetProsumption(int id)
        {
            Prosumption prosumption = await db.Prosumptions.FindAsync(id);
            if (prosumption == null)
            {
                return NotFound();
            }

            return Ok(prosumption);
        }

        // PUT: api/Prosumptions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProsumption(int id, Prosumption prosumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prosumption.ProsumptionId)
            {
                return BadRequest();
            }

            db.Entry(prosumption).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProsumptionExists(id))
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

        // POST: api/Prosumptions
        [ResponseType(typeof(Prosumption))]
        public async Task<IHttpActionResult> PostProsumption(Prosumption prosumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prosumptions.Add(prosumption);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = prosumption.ProsumptionId }, prosumption);
        }

        // DELETE: api/Prosumptions/5
        [ResponseType(typeof(Prosumption))]
        public async Task<IHttpActionResult> DeleteProsumption(int id)
        {
            Prosumption prosumption = await db.Prosumptions.FindAsync(id);
            if (prosumption == null)
            {
                return NotFound();
            }

            db.Prosumptions.Remove(prosumption);
            await db.SaveChangesAsync();

            return Ok(prosumption);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProsumptionExists(int id)
        {
            return db.Prosumptions.Count(e => e.ProsumptionId == id) > 0;
        }
    }
}