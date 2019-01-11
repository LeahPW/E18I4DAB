using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ProsumerGrid.Models;
using ProsumerGrid.Models.Prosumer;
using ProsumerGrid.Services;
using ProsumerGrid.Services.Prosumer;

namespace ProsumerGrid.Controllers
{
    public class ProsumerController : Controller
    {
        private ProsumerGridContext db = new ProsumerGridContext();

        private ProsumerService _prosumerService;

        public ProsumerController()
        {
            _prosumerService = new ProsumerService();
        }

        // GET: Prosumers
        public async Task<ActionResult> Index()
        {
            //var prosumers = db.Prosumers.Include(p => p.SmartMeter);
            //IEnumerable<ProsumerDTO> prosumers = null;

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:14065/api/");

            //    var responseTask = client.GetAsync("prosumers");
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<IList<ProsumerDTO>>();
            //        readTask.Wait();

            //        prosumers = readTask.Result;
            //    }
            //    else
            //    {
            //        prosumers = Enumerable.Empty<ProsumerDTO>();
            //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //    }
            //}

            List<ProsumerInfoDTO> prosumers = _prosumerService.GetAllProsumers();
            return View(prosumers);
        }

        // GET: Prosumers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProsumerInfo prosumer = await db.Prosumers.FindAsync(id);
            if (prosumer == null)
            {
                return HttpNotFound();
            }
            return View(prosumer);
        }

        // GET: Prosumers/Create
        public ActionResult Create()
        {
            ViewBag.SmartMeterId = new SelectList(db.SmartMeters, "SmartMeterId", "IpAddress");
            return View();
        }

        // POST: Prosumers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProsumerId,Type,Address,SmartMeterId")] ProsumerInfo prosumer)
        {
            if (ModelState.IsValid)
            {
                db.Prosumers.Add(prosumer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SmartMeterId = new SelectList(db.SmartMeters, "SmartMeterId", "IpAddress", prosumer.Id);
            return View(prosumer);
        }

        // GET: Prosumers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProsumerInfo prosumer = await db.Prosumers.FindAsync(id);
            if (prosumer == null)
            {
                return HttpNotFound();
            }
            ViewBag.SmartMeterId = new SelectList(db.SmartMeters, "SmartMeterId", "IpAddress", prosumer.Id);
            return View(prosumer);
        }

        // POST: Prosumers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProsumerId,Type,Address,SmartMeterId")] ProsumerInfo prosumer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prosumer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SmartMeterId = new SelectList(db.SmartMeters, "SmartMeterId", "IpAddress", prosumer.Id);
            return View(prosumer);
        }

        // GET: Prosumers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProsumerInfo prosumer = await db.Prosumers.FindAsync(id);
            if (prosumer == null)
            {
                return HttpNotFound();
            }
            return View(prosumer);
        }

        // POST: Prosumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProsumerInfo prosumer = await db.Prosumers.FindAsync(id);
            db.Prosumers.Remove(prosumer);
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
