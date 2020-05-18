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
    public class LoanTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LoanTypes
        public ActionResult Index()
        {
            return View(db.LoanTypes.ToList());
        }

        // GET: LoanTypes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanType loanType = db.LoanTypes.Find(id);
            if (loanType == null)
            {
                return HttpNotFound();
            }
            return View(loanType);
        }

        // GET: LoanTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Loan_Type,LoanRate")] LoanType loanType)
        {
            if (ModelState.IsValid)
            {
                db.LoanTypes.Add(loanType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loanType);
        }

        // GET: LoanTypes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanType loanType = db.LoanTypes.Find(id);
            if (loanType == null)
            {
                return HttpNotFound();
            }
            return View(loanType);
        }

        // POST: LoanTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Loan_Type,LoanRate")] LoanType loanType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loanType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loanType);
        }

        // GET: LoanTypes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoanType loanType = db.LoanTypes.Find(id);
            if (loanType == null)
            {
                return HttpNotFound();
            }
            return View(loanType);
        }

        // POST: LoanTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoanType loanType = db.LoanTypes.Find(id);
            db.LoanTypes.Remove(loanType);
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
