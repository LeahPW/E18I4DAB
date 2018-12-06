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
    public class InfoController : ApiController
    {
        private ProsumerInfoContext db = new ProsumerInfoContext();

        // GET: api/Info
        public IQueryable<Info> GetInfoes()
        {
            return db.Infoes;
        }

        // GET: api/Info/5
        [ResponseType(typeof(Info))]
        public async Task<IHttpActionResult> GetInfo(int id)
        {
            Info info = await db.Infoes.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }

            return Ok(info);
        }

        // PUT: api/Info/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInfo(int id, Info info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != info.ProsumerId)
            {
                return BadRequest();
            }

            db.Entry(info).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoExists(id))
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

        // POST: api/Info
        [ResponseType(typeof(Info))]
        public async Task<IHttpActionResult> PostInfo(Info info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Infoes.Add(info);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = info.ProsumerId }, info);
        }

        // DELETE: api/Info/5
        [ResponseType(typeof(Info))]
        public async Task<IHttpActionResult> DeleteInfo(int id)
        {
            Info info = await db.Infoes.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }

            db.Infoes.Remove(info);
            await db.SaveChangesAsync();

            return Ok(info);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InfoExists(int id)
        {
            return db.Infoes.Count(e => e.ProsumerId == id) > 0;
        }
    }
}