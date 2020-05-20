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
    [Authorize]
    public class LoansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Loans
        public ActionResult Index()
        {
            var loans = db.Loans.Include(l => l.DVDDetails).Include(l => l.Members);
            return View(loans.ToList());
        }

        // GET: Loans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // Function 5

        public ActionResult FilterFunction5(int? NoOfCopy)
        {
            ViewBag.NoOfCopy = db.DVDDetails.ToList();
            if (NoOfCopy.GetValueOrDefault(0) == 0)
            {
                return View();

            }
            var data = db.Loans.Include("DVDDetails").Include("Members").Where(x => x.DVDDetails.NoOfCopy == NoOfCopy).ToList();


            return View(data);
        }


        // GET: Loans/Create
        public ActionResult Create()
        {
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title");
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name");
            return View();
        }
        public ActionResult Loan31Days(String Name)
        {
           
            ViewBag.MemberID = db.Members.ToList();
            if (String.IsNullOrEmpty(Name))
            {
                return View();

            }
            var baselineDate = DateTime.Now.AddDays(-31);

       
            var data = db.Loans.Include(d => d.Members).Include(d => d.DVDDetails).Where(d =>d.IssuedDate >= baselineDate && d.Members.Name==Name).ToList();

            return View(data);
        }

        // POST: Loans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoanId,IssuedDate,ReturnedDate,TotalFine,DVDId,MemberId")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Loans.Add(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", loan.DVDId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", loan.MemberId);
            return View(loan);
        }

        // GET: Loans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", loan.DVDId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", loan.MemberId);
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoanId,IssuedDate,ReturnedDate,TotalFine,DVDId,MemberId")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", loan.DVDId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", loan.MemberId);
            return View(loan);
        }

        // GET: Loans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.Loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loan loan = db.Loans.Find(id);
            db.Loans.Remove(loan);
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
