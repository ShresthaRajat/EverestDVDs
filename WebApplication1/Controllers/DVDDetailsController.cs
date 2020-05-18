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
    public class DVDDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DVDDetails
        public ActionResult Index()
        {
            return View(db.DVDDetails.ToList());
        }

        // GET: DVDDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDDetail dVDDetail = db.DVDDetails.Find(id);
            if (dVDDetail == null)
            {
                return HttpNotFound();
            }
            return View(dVDDetail);
        }

        // GET: DVDDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DVDDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DVDId,Title,Genre,NoOfCopy,AgeRestriction,StudioName,DVDCover,DateAdded")] DVDDetail dVDDetail)
        {
            if (ModelState.IsValid)
            {
                db.DVDDetails.Add(dVDDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dVDDetail);
        }

        // GET: DVDDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDDetail dVDDetail = db.DVDDetails.Find(id);
            if (dVDDetail == null)
            {
                return HttpNotFound();
            }
            return View(dVDDetail);
        }

        // POST: DVDDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DVDId,Title,Genre,NoOfCopy,AgeRestriction,StudioName,DVDCover,DateAdded")] DVDDetail dVDDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dVDDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dVDDetail);
        }

        // GET: DVDDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DVDDetail dVDDetail = db.DVDDetails.Find(id);
            if (dVDDetail == null)
            {
                return HttpNotFound();
            }
            return View(dVDDetail);
        }

        // POST: DVDDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DVDDetail dVDDetail = db.DVDDetails.Find(id);
            db.DVDDetails.Remove(dVDDetail);
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
