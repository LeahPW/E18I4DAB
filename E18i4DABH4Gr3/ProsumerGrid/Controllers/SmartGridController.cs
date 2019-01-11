using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProsumerGrid.Models;
using ProsumerGrid.Models.SmartGrid;
using ProsumerGrid.Services.SmartGrid;

namespace ProsumerGrid.Controllers
{
    public class SmartGridController : Controller
    {
        //private ProsumerGridContext db = new ProsumerGridContext();

        private SmartGridService _gridService;

        public SmartGridController()
        {
            _gridService = new SmartGridService();
        }

        public ActionResult UpdateTerm()
        {
            _gridService.UpdateTerm();
            return Index();
        }

        // GET: Trades
        public ActionResult Index()
        {
            List<NodeDTO> nodes = _gridService.GetNodeList();
            Grid g = _gridService.GetGrid();
            var model = new SmartGridViewModel
            {
                Nodes = nodes,
                Grid = new GridDTO
                {
                    Id = g.Id, Balance = g.Balance, Production = g.Production, Consumption = g.Consumption,
                    Term = g.Term, BlockExchangeValue = g.BlockExchangeValue, Name = g.Name
                }
            };
            return View("Overview", model);
        }

        //// GET: SmartGrid/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Node node = db.Nodes.Find(id);
        //    if (node == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(node);
        //}

        //// GET: SmartGrid/Create
        //public ActionResult Create()
        //{
        //    ViewBag.GridId = new SelectList(db.Grid, "Id", "Name");
        //    ViewBag.ProsumerInfoId = new SelectList(db.Prosumers, "Id", "Type");
        //    ViewBag.SmartMeterId = new SelectList(db.SmartMeters, "Id", "IpAddress");
        //    return View();
        //}

        //// POST: SmartGrid/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Production,Consumption,Balance,GridId,ProsumerInfoId,SmartMeterId")] Node node)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Nodes.Add(node);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.GridId = new SelectList(db.Grid, "Id", "Name", node.GridId);
        //    ViewBag.ProsumerInfoId = new SelectList(db.Prosumers, "Id", "Type", node.ProsumerInfoId);
        //    ViewBag.SmartMeterId = new SelectList(db.SmartMeters, "Id", "IpAddress", node.SmartMeterId);
        //    return View(node);
        //}

        //// GET: SmartGrid/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Node node = db.Nodes.Find(id);
        //    if (node == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.GridId = new SelectList(db.Grid, "Id", "Name", node.GridId);
        //    ViewBag.ProsumerInfoId = new SelectList(db.Prosumers, "Id", "Type", node.ProsumerInfoId);
        //    ViewBag.SmartMeterId = new SelectList(db.SmartMeters, "Id", "IpAddress", node.SmartMeterId);
        //    return View(node);
        //}

        //// POST: SmartGrid/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Production,Consumption,Balance,GridId,ProsumerInfoId,SmartMeterId")] Node node)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(node).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.GridId = new SelectList(db.Grid, "Id", "Name", node.GridId);
        //    ViewBag.ProsumerInfoId = new SelectList(db.Prosumers, "Id", "Type", node.ProsumerInfoId);
        //    ViewBag.SmartMeterId = new SelectList(db.SmartMeters, "Id", "IpAddress", node.SmartMeterId);
        //    return View(node);
        //}

        //// GET: SmartGrid/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Node node = db.Nodes.Find(id);
        //    if (node == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(node);
        //}

        //// POST: SmartGrid/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Node node = db.Nodes.Find(id);
        //    db.Nodes.Remove(node);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
