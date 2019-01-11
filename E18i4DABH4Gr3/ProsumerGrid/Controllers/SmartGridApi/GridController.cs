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
    public class GridController : ApiController
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        // GET: api/Grid
        public IQueryable<Grid> GetGrid()
        {
            return db.Grid;
        }

        // GET: api/Grid/5
        [ResponseType(typeof(Grid))]
        public async Task<IHttpActionResult> GetGrid(int id)
        {
            Grid grid = await db.Grid.FindAsync(id);
            if (grid == null)
            {
                return NotFound();
            }

            return Ok(grid);
        }

        // PUT: api/Grid/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGrid(int id, Grid grid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grid.GridId)
            {
                return BadRequest();
            }

            db.Entry(grid).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GridExists(id))
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

        // POST: api/Grid
        [ResponseType(typeof(Grid))]
        public async Task<IHttpActionResult> PostGrid(Grid grid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grid.Add(grid);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = grid.GridId }, grid);
        }

        // DELETE: api/Grid/5
        [ResponseType(typeof(Grid))]
        public async Task<IHttpActionResult> DeleteGrid(int id)
        {
            Grid grid = await db.Grid.FindAsync(id);
            if (grid == null)
            {
                return NotFound();
            }

            db.Grid.Remove(grid);
            await db.SaveChangesAsync();

            return Ok(grid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GridExists(int id)
        {
            return db.Grid.Count(e => e.GridId == id) > 0;
        }
    }
}