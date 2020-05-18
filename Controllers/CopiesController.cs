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
    public class CopiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Copies
        public ActionResult Index()
        {
            var copies = db.Copies.Include(c => c.DVDz);
            return View(copies.ToList());
        }

        // GET: Copies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copies copies = db.Copies.Find(id);
            if (copies == null)
            {
                return HttpNotFound();
            }
            return View(copies);
        }

        // GET: Copies/Create
        public ActionResult Create()
        {
            ViewBag.DVDTilte = new SelectList(db.DVDs, "DVDTitle", "DVDStudio");
            return View();
        }

        // POST: Copies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CopyNumber,DVDTilte")] Copies copies)
        {
            if (ModelState.IsValid)
            {
                db.Copies.Add(copies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DVDTilte = new SelectList(db.DVDs, "DVDTitle", "DVDStudio", copies.DVDTilte);
            return View(copies);
        }

        // GET: Copies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copies copies = db.Copies.Find(id);
            if (copies == null)
            {
                return HttpNotFound();
            }
            ViewBag.DVDTilte = new SelectList(db.DVDs, "DVDTitle", "DVDStudio", copies.DVDTilte);
            return View(copies);
        }

        // POST: Copies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CopyNumber,DVDTilte")] Copies copies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DVDTilte = new SelectList(db.DVDs, "DVDTitle", "DVDStudio", copies.DVDTilte);
            return View(copies);
        }

        // GET: Copies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copies copies = db.Copies.Find(id);
            if (copies == null)
            {
                return HttpNotFound();
            }
            return View(copies);
        }

        // POST: Copies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Copies copies = db.Copies.Find(id);
            db.Copies.Remove(copies);
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
