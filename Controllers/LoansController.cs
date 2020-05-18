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
    public class LoansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Loans
        public ActionResult Index()
        {
            var loans = db.Loans.Include(l => l.Copiez).Include(l => l.LoanTypes).Include(l => l.Memberz);
            return View(loans.ToList());
        }

        // GET: Loans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loans loans = db.Loans.Find(id);
            if (loans == null)
            {
                return HttpNotFound();
            }
            return View(loans);
        }

        // GET: Loans/Create
        public ActionResult Create()
        {
            ViewBag.CopyId = new SelectList(db.Copies, "CopyNumber", "DVDTilte");
            ViewBag.LoanType = new SelectList(db.LoanTypes, "Loan_Type", "Loan_Type");
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,CopyId,IssueDate,ReturnDate,LoanType")] Loans loans)
        {
            if (ModelState.IsValid)
            {
                db.Loans.Add(loans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CopyId = new SelectList(db.Copies, "CopyNumber", "DVDTilte", loans.CopyId);
            ViewBag.LoanType = new SelectList(db.LoanTypes, "Loan_Type", "Loan_Type", loans.LoanType);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", loans.MemberId);
            return View(loans);
        }

        // GET: Loans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loans loans = db.Loans.Find(id);
            if (loans == null)
            {
                return HttpNotFound();
            }
            ViewBag.CopyId = new SelectList(db.Copies, "CopyNumber", "DVDTilte", loans.CopyId);
            ViewBag.LoanType = new SelectList(db.LoanTypes, "Loan_Type", "Loan_Type", loans.LoanType);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", loans.MemberId);
            return View(loans);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,CopyId,IssueDate,ReturnDate,LoanType")] Loans loans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CopyId = new SelectList(db.Copies, "CopyNumber", "DVDTilte", loans.CopyId);
            ViewBag.LoanType = new SelectList(db.LoanTypes, "Loan_Type", "Loan_Type", loans.LoanType);
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", loans.MemberId);
            return View(loans);
        }

        // GET: Loans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loans loans = db.Loans.Find(id);
            if (loans == null)
            {
                return HttpNotFound();
            }
            return View(loans);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loans loans = db.Loans.Find(id);
            db.Loans.Remove(loans);
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
