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
    public class MembershipCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MembershipCategories
        public ActionResult Index()
        {
            return View(db.MembershipCategories.ToList());
        }

        // GET: MembershipCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipCategories membershipCategories = db.MembershipCategories.Find(id);
            if (membershipCategories == null)
            {
                return HttpNotFound();
            }
            return View(membershipCategories);
        }

        // GET: MembershipCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembershipCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MembershipCategory,TotalLoan")] MembershipCategories membershipCategories)
        {
            if (ModelState.IsValid)
            {
                db.MembershipCategories.Add(membershipCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membershipCategories);
        }

        // GET: MembershipCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipCategories membershipCategories = db.MembershipCategories.Find(id);
            if (membershipCategories == null)
            {
                return HttpNotFound();
            }
            return View(membershipCategories);
        }

        // POST: MembershipCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MembershipCategory,TotalLoan")] MembershipCategories membershipCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membershipCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membershipCategories);
        }

        // GET: MembershipCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipCategories membershipCategories = db.MembershipCategories.Find(id);
            if (membershipCategories == null)
            {
                return HttpNotFound();
            }
            return View(membershipCategories);
        }

        // POST: MembershipCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MembershipCategories membershipCategories = db.MembershipCategories.Find(id);
            db.MembershipCategories.Remove(membershipCategories);
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
