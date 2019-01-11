using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProsumerGrid.Models;
using ProsumerGrid.Models.Prosumer;

namespace ProsumerGrid.Controllers
{
    public class ProsumerInfoesController : Controller
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        // GET: ProsumerInfoes
        public ActionResult Index()
        {
            return View(db.Prosumers.ToList());
        }

        // GET: ProsumerInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProsumerInfo prosumerInfo = db.Prosumers.Find(id);
            if (prosumerInfo == null)
            {
                return HttpNotFound();
            }
            return View(prosumerInfo);
        }

        // GET: ProsumerInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProsumerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Address")] ProsumerInfo prosumerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Prosumers.Add(prosumerInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prosumerInfo);
        }

        // GET: ProsumerInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProsumerInfo prosumerInfo = db.Prosumers.Find(id);
            if (prosumerInfo == null)
            {
                return HttpNotFound();
            }
            return View(prosumerInfo);
        }

        // POST: ProsumerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Address")] ProsumerInfo prosumerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prosumerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prosumerInfo);
        }

        // GET: ProsumerInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProsumerInfo prosumerInfo = db.Prosumers.Find(id);
            if (prosumerInfo == null)
            {
                return HttpNotFound();
            }
            return View(prosumerInfo);
        }

        // POST: ProsumerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProsumerInfo prosumerInfo = db.Prosumers.Find(id);
            db.Prosumers.Remove(prosumerInfo);
            db.SaveChanges();
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
