using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DVDProducersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DVDProducers
        public ActionResult Index()
        {
            var dVDProducers = db.DVDProducers.Include(d => d.DVDDetails).Include(d => d.Producers);
            return View(dVDProducers.ToList());
        }

        // GET: DVDProducers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDProducer dVDProducer = db.DVDProducers.Find(id);
            if (dVDProducer == null)
            {
                return HttpNotFound();
            }
            return View(dVDProducer);
        }

        // GET: DVDProducers/Create
        public ActionResult Create()
        {
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title");
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "ProducerName");
            return View();
        }

        // POST: DVDProducers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProducerId,DVDId")] DVDProducer dVDProducer)
        {
            if (ModelState.IsValid)
            {
                db.DVDProducers.Add(dVDProducer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", dVDProducer.DVDId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "ProducerName", dVDProducer.ProducerId);
            return View(dVDProducer);
        }

        // GET: DVDProducers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDProducer dVDProducer = db.DVDProducers.Find(id);
            if (dVDProducer == null)
            {
                return HttpNotFound();
            }
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", dVDProducer.DVDId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "ProducerName", dVDProducer.ProducerId);
            return View(dVDProducer);
        }

        // POST: DVDProducers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProducerId,DVDId")] DVDProducer dVDProducer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVDProducer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", dVDProducer.DVDId);
            ViewBag.ProducerId = new SelectList(db.Producers, "ProducerId", "ProducerName", dVDProducer.ProducerId);
            return View(dVDProducer);
        }

        // GET: DVDProducers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDProducer dVDProducer = db.DVDProducers.Find(id);
            if (dVDProducer == null)
            {
                return HttpNotFound();
            }
            return View(dVDProducer);
        }

        // POST: DVDProducers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DVDProducer dVDProducer = db.DVDProducers.Find(id);
            db.DVDProducers.Remove(dVDProducer);
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
