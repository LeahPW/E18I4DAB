using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProsumerGrid.Models;
using ProsumerGrid.Models.SmartGrid;

namespace ProsumerGrid.Controllers
{
    public class SmartGridController : Controller
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        // GET: SmartGrid
        public async Task<ActionResult> Index()
        {
            var nodes = db.Nodes.Include(n => n.Grid).Include(n => n.Prosumer);
            return View(await nodes.ToListAsync());
        }

        // GET: SmartGrid/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // GET: SmartGrid/Create
        public ActionResult Create()
        {
            ViewBag.GridId = new SelectList(db.Grid, "GridId", "Name");
            ViewBag.ProsumerId = new SelectList(db.Prosumers, "ProsumerId", "Type");
            return View();
        }

        // POST: SmartGrid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NodeId,Balance,ProsumerId,GridId")] Node node)
        {
            if (ModelState.IsValid)
            {
                db.Nodes.Add(node);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GridId = new SelectList(db.Grid, "GridId", "Name", node.GridId);
            ViewBag.ProsumerId = new SelectList(db.Prosumers, "ProsumerId", "Type", node.ProsumerId);
            return View(node);
        }

        // GET: SmartGrid/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            ViewBag.GridId = new SelectList(db.Grid, "GridId", "Name", node.GridId);
            ViewBag.ProsumerId = new SelectList(db.Prosumers, "ProsumerId", "Type", node.ProsumerId);
            return View(node);
        }

        // POST: SmartGrid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NodeId,Balance,ProsumerId,GridId")] Node node)
        {
            if (ModelState.IsValid)
            {
                db.Entry(node).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GridId = new SelectList(db.Grid, "GridId", "Name", node.GridId);
            ViewBag.ProsumerId = new SelectList(db.Prosumers, "ProsumerId", "Type", node.ProsumerId);
            return View(node);
        }

        // GET: SmartGrid/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // POST: SmartGrid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Node node = await db.Nodes.FindAsync(id);
            db.Nodes.Remove(node);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
