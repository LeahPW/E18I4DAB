using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E18i4DABH4Gr3.Models;
using ProsumerGrid.Models;
using ProsumerGrid.Models.Trade;
using ProsumerGrid.Services.Prosumer;
using ProsumerGrid.Services.Trade;

namespace ProsumerGrid.Controllers
{
    public class TradesController : Controller
    {
        //private ProsumerGridContext db = new ProsumerGridContext();

        private TradeService _tradeService;

        public TradesController()
        {
            _tradeService = new TradeService();
        }

        // GET: Trades
        public ActionResult Index()
        {
            List<TradeDTO> tradelist = _tradeService.GetAll();
            return View("Overview", tradelist);
        }

        // GET: Trades/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Produce,Prosumed,MonetaryValue,Status,TradeTime,ProsumerId")] Trade trade)
        {
            if (ModelState.IsValid)
            {
                //db.Trades.Add(trade);
                //db.SaveChanges();
                var result = _tradeService.AddTrade(trade);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(trade);
        }

        //// GET: Trades/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Trade trade = db.Trades.Find(id);
        //    if (trade == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trade);
        //}



        // POST: Trades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        //// GET: Trades/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Trade trade = db.Trades.Find(id);
        //    if (trade == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trade);
        //}

        //// POST: Trades/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Produce,Prosumed,MonetaryValue,Status,TradeTime,ProsumerId")] Trade trade)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(trade).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(trade);
        //}

        //// GET: Trades/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Trade trade = db.Trades.Find(id);
        //    if (trade == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(trade);
        //}

        //// POST: Trades/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Trade trade = db.Trades.Find(id);
        //    db.Trades.Remove(trade);
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
