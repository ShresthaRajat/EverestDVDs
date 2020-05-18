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
    public class DVDCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DVDCategories
        public ActionResult Index()
        {
            return View(db.DVDCategories.ToList());
        }

        // GET: DVDCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDCategories dVDCategories = db.DVDCategories.Find(id);
            if (dVDCategories == null)
            {
                return HttpNotFound();
            }
            return View(dVDCategories);
        }

        // GET: DVDCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DVDCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DVDsCategory,AgeRestricted")] DVDCategories dVDCategories)
        {
            if (ModelState.IsValid)
            {
                db.DVDCategories.Add(dVDCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dVDCategories);
        }

        // GET: DVDCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDCategories dVDCategories = db.DVDCategories.Find(id);
            if (dVDCategories == null)
            {
                return HttpNotFound();
            }
            return View(dVDCategories);
        }

        // POST: DVDCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DVDsCategory,AgeRestricted")] DVDCategories dVDCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVDCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dVDCategories);
        }

        // GET: DVDCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDCategories dVDCategories = db.DVDCategories.Find(id);
            if (dVDCategories == null)
            {
                return HttpNotFound();
            }
            return View(dVDCategories);
        }

        // POST: DVDCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DVDCategories dVDCategories = db.DVDCategories.Find(id);
            db.DVDCategories.Remove(dVDCategories);
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
