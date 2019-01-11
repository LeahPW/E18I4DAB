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
    public class NodesController : ApiController
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        // GET: api/Nodes
        public IQueryable<Node> GetNodes()
        {
            return db.Nodes;
        }

        // GET: api/Nodes/5
        [ResponseType(typeof(Node))]
        public async Task<IHttpActionResult> GetNode(int id)
        {
            var node = await db.Nodes.Include(n => n.Grid).Select(n =>
                new NodeDTO()
                {
                    Id = n.Id,
                    ProsumerInfoId = n.ProsumerInfoId,
                    Balance = n.Balance,
                    GridName = n.Grid.Name,
                    GridBalance = n.Grid.Balance,
                    GridBlockExchangeValue = n.Grid.BlockExchangeValue,
                }).SingleOrDefaultAsync(n => n.Id == id);

            if (node == null)
            {
                return NotFound();
            }

            return Ok(node);
        }

        // PUT: api/Nodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNode(int id, Node node)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != node.Id)
            {
                return BadRequest();
            }

            db.Entry(node).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodeExists(id))
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

        // POST: api/Nodes
        [ResponseType(typeof(Node))]
        public async Task<IHttpActionResult> PostNode(Node node)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nodes.Add(node);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = node.Id }, node);
        }

        // DELETE: api/Nodes/5
        [ResponseType(typeof(Node))]
        public async Task<IHttpActionResult> DeleteNode(int id)
        {
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }

            db.Nodes.Remove(node);
            await db.SaveChangesAsync();

            return Ok(node);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NodeExists(int id)
        {
            return db.Nodes.Count(e => e.Id == id) > 0;
        }
    }
}