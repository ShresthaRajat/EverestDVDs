using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Everest_DVD_Store.Models;

namespace Everest_DVD_Store.Controllers
{
    public class DVDsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DVDs
        public ActionResult Index()
        {
            var dVDs = db.DVDs.Include(d => d.DVDz);
            return View(dVDs.ToList());
        }

        // GET: DVDs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDs dVDs = db.DVDs.Find(id);
            if (dVDs == null)
            {
                return HttpNotFound();
            }
            return View(dVDs);
        }

        // GET: DVDs/Create
        public ActionResult Create()
        {
            ViewBag.DVDsCategory = new SelectList(db.DVDs, "DVDTitle", "DVDStudio");
            return View();
        }

        // POST: DVDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DVDTitle,DVDStudio,DVDProducer,RunTime,DVDsCategory,ReleaseDate")] DVDs dVDs)
        {
            if (ModelState.IsValid)
            {
                db.DVDs.Add(dVDs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DVDsCategory = new SelectList(db.DVDs, "DVDTitle", "DVDStudio", dVDs.DVDsCategory);
            return View(dVDs);
        }

        // GET: DVDs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDs dVDs = db.DVDs.Find(id);
            if (dVDs == null)
            {
                return HttpNotFound();
            }
            ViewBag.DVDsCategory = new SelectList(db.DVDs, "DVDTitle", "DVDStudio", dVDs.DVDsCategory);
            return View(dVDs);
        }

        // POST: DVDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DVDTitle,DVDStudio,DVDProducer,RunTime,DVDsCategory,ReleaseDate")] DVDs dVDs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVDs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DVDsCategory = new SelectList(db.DVDs, "DVDTitle", "DVDStudio", dVDs.DVDsCategory);
            return View(dVDs);
        }

        // GET: DVDs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDs dVDs = db.DVDs.Find(id);
            if (dVDs == null)
            {
                return HttpNotFound();
            }
            return View(dVDs);
        }

        // POST: DVDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DVDs dVDs = db.DVDs.Find(id);
            db.DVDs.Remove(dVDs);
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
