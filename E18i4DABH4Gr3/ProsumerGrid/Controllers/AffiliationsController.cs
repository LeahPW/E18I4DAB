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
    public class AffiliationsController : ApiController
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        // GET: api/Affiliations
        public IQueryable<AffiliationDTO> GetAffiliations()
        {
            var affiliations = from b in db.Affiliations
                select new AffiliationDTO()
                {
                    AffiliationId = b.AffiliationId,
                    MemberName = b.Member.Name,
                    ProsumerAddress = b.Prosumer.Address,
                    SmartMeterIp = b.Prosumer.SmartMeter.IpAddress
                };
            return affiliations;
            //old code
            //return db.Affiliations;
        }

        // GET: api/Affiliations/5
        [ResponseType(typeof(Affiliation))]
        public async Task<IHttpActionResult> GetAffiliation(int id)
        {
            var affiliation= await db.Affiliations.Include(b => b.Member).Include(b=>b.Prosumer).Select(b =>
                new AffiliationDTO()
                {
                    AffiliationId = b.AffiliationId,
                    MemberName = b.Member.Name,
                    ProsumerAddress = b.Prosumer.Address,
                    SmartMeterIp = b.Prosumer.SmartMeter.IpAddress
                }).SingleOrDefaultAsync(b => b.AffiliationId == id);

            if (affiliation == null)
            {
                return NotFound();
            }

            return Ok(affiliation);

            //old code

            //Affiliation affiliation = await db.Affiliations.FindAsync(id);
            //if (affiliation == null)
            //{
            //    return NotFound();
            //}

            //return Ok(affiliation);
        }

        // PUT: api/Affiliations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAffiliation(int id, Affiliation affiliation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != affiliation.AffiliationId)
            {
                return BadRequest();
            }

            db.Entry(affiliation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AffiliationExists(id))
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

        // POST: api/Affiliations
        [ResponseType(typeof(Affiliation))]
        public async Task<IHttpActionResult> PostAffiliation(Affiliation affiliation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Affiliations.Add(affiliation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = affiliation.AffiliationId }, affiliation);
        }

        // DELETE: api/Affiliations/5
        [ResponseType(typeof(Affiliation))]
        public async Task<IHttpActionResult> DeleteAffiliation(int id)
        {
            Affiliation affiliation = await db.Affiliations.FindAsync(id);
            if (affiliation == null)
            {
                return NotFound();
            }

            db.Affiliations.Remove(affiliation);
            await db.SaveChangesAsync();

            return Ok(affiliation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AffiliationExists(int id)
        {
            return db.Affiliations.Count(e => e.AffiliationId == id) > 0;
        }
    }
}