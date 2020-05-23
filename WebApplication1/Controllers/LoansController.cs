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

        public ActionResult FilterFunction5(String NoOfCopy)
        {
            ViewBag.NoOfCopy = db.DVDDetails.ToList();
            if (String.IsNullOrEmpty(NoOfCopy))
            {
                return View();

            }
            var data = db.Loans.Include("DVDDetails").Include("Members").Where(x => x.DVDDetails.NoOfCopy == NoOfCopy).ToList();


            return View(data);
        }


        public ActionResult FunctionNo8()
        {
            var data = (from l in db.Loans
                        where l.ReturnedDate == null
                        group l by new { l.MemberId } into table1
                        select new
                        {
                            NumberOfLoans = table1.Count(),
                            MemberId = table1.Key.MemberId,


                        }).ToList().Select(x => new LoanViewModel()
                        {
                            NumberOfLoans = x.NumberOfLoans,
                            MemberId = x.MemberId
                        });

            var d = (from l in data
                     join mc in db.Members on
                     l.MemberId equals mc.MemberId
                     join mcc in db.MemberCategories on
                     mc.CategoryId equals mcc.CategoryId
                     select new
                     {
                         MemberId = l.MemberId,

                         Name = mc.Name,
                         CName = mcc.Name,
                         NumberOfLoans = l.NumberOfLoans,
                         LoanStatus = (l.NumberOfLoans > mcc.TotalLoan ? "Too much DVD" : "Not Loaned too much")
                         // LoanStatus = (g.Count() > g.Key.DVDLimit ? "Too much DVD" : "Not Loaned too much")

                     }
                     ).ToList().Select(x => new LoanViewModel
                     {
                         MemberId = x.MemberId,
                         Name = x.Name,
                         CName = x.CName,
                         NumberOfLoans = x.NumberOfLoans,
                         LoanStatus = x.LoanStatus

                     }

                     )
                     ;

            var dd = d.OrderBy(x => x.Name);
            return View(dd);
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


            var data = db.Loans.Include(d => d.Members).Include(d => d.DVDDetails).Where(d => d.IssuedDate >= baselineDate && d.Members.Name == Name).ToList();

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
                ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", loan.DVDId);
                ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", loan.MemberId);
                var data = loan.DVDId;
                var member = loan.MemberId;
                DVDDetail dvd = db.DVDDetails.Find(data);
                int memberId = member;
                int dvdId = data;
                CheckDvdStock(dvdId);
                string ageVerify = dvd.AgeRestriction;
                if (CheckLoanNumbers(memberId) == true)
                {
                    if (CheckDvdStock(dvdId) == true)
                    {
                        if (ageVerify == "18+")
                        {
                            if (CheckAge(memberId) == true)
                            {
                                if (data != null)
                                {
                                    string copyNumber = dvd.NoOfCopy;
                                    int cn = int.Parse(copyNumber);
                                    int cnn = cn - 1;
                                    copyNumber = cnn.ToString();
                                    dvd.NoOfCopy = copyNumber;
                                    db.Entry(dvd).State = EntityState.Modified;
                                    db.SaveChanges();
                                }
                                db.Loans.Add(loan);
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.ErrorMessage = "This Nigga is too small to watch the movie";
                                return View();
                            }
                        }
                        else
                        {
                            if (data != null)
                            {
                                string copyNumber = dvd.NoOfCopy;
                                int cn = int.Parse(copyNumber);
                                int cnn = cn - 1;
                                copyNumber = cnn.ToString();
                                dvd.NoOfCopy = copyNumber;
                                db.Entry(dvd).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            db.Loans.Add(loan);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "The Dvd is out of stock";
                        return View();
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "According to the Member Category the Dvd loan has exceeded!";
                    return View();
                }
            }
            return View(loan);
        }

        public ActionResult Function12()
        {
            List<Loan> loans = db.Loans.ToList();

            List<Member> members = db.Members.ToList();

            List<DVDDetail> dVDDetails = db.DVDDetails.ToList();

            var data = from l in loans
                       join m in members on l.MemberId equals m.MemberId into table1
                       from m in table1.ToList()
                       join d in dVDDetails on l.DVDId equals d.DVDId into table2
                       from d in table2.ToList()
                       select new Function12Model
                       {
                           loan = l,
                           dVDDetail = d,
                           member = m
                       };
            DateTime baselineDate = DateTime.Now.AddDays(-31);
            var data1 = data.Where(d => d.loan.IssuedDate <= baselineDate).OrderBy(x => x.loan.IssuedDate);
            // var data1 = db.Function12Model.Where(d => d.loan.IssuedDate >= baselineDate);
            //var data1 = db.Loans.Include(d => d.Members).Include(d => d.DVDDetails).Where(d => d.IssuedDate >= baselineDate && d.Members.Name == Name).ToList();
            return View(data1);
        }

        public ActionResult Function13()
        {
            List<Loan> loans = db.Loans.ToList();

            List<Member> members = db.Members.ToList();

            List<DVDDetail> dVDDetails = db.DVDDetails.ToList();

            var data = from l in loans
                       join m in members on l.MemberId equals m.MemberId into table1
                       from m in table1.ToList()
                       join d in dVDDetails on l.DVDId equals d.DVDId into table2
                       from d in table2.ToList()
                       select new Function12Model
                       {
                           loan = l,
                           dVDDetail = d,
                           member = m
                       };
            DateTime baselineDate = DateTime.Now.AddDays(-31);
            var data1 = data.Where(d => d.loan.IssuedDate <= baselineDate).OrderBy(x => x.loan.IssuedDate);
            // var data1 = db.Function12Model.Where(d => d.loan.IssuedDate >= baselineDate);
            //var data1 = db.Loans.Include(d => d.Members).Include(d => d.DVDDetails).Where(d => d.IssuedDate >= baselineDate && d.Members.Name == Name).ToList();
            return View(data1);
        }
        public Boolean CheckAge(int memberId)
        {
            Member member = db.Members.Find(memberId);
            DateTime dob = member.DOB;
            DateTime todayDate = DateTime.Today;
            TimeSpan timeSpan = todayDate.Subtract(dob);
            int years = timeSpan.Days / 365;
            if (years >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Boolean CheckLoanNumbers(int memberId)
        {
            Member member = db.Members.Find(memberId);
            string memberName = member.Name;
            int memberCategoryId = member.CategoryId;
            MemberCategory memberCategory = db.MemberCategories.Find(memberCategoryId);
            int? loan = memberCategory.TotalLoan;
            var list = db.Loans.Include("Member").Where(x => x.Members.Name == memberName).Count();
            if (list > loan)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean CheckDvdStock(int dvdId)
        {
            DVDDetail dvd = db.DVDDetails.Find(dvdId);
            string cp = dvd.NoOfCopy;
            int copyNumber = int.Parse(cp);
            if (copyNumber > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
                ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", loan.DVDId);
                ViewBag.MemberId = new SelectList(db.Members, "MemberId", "Name", loan.MemberId);
                var data = loan.DVDId;
                if (loan.ReturnedDate != null)
                {
                    DVDDetail dvd = db.DVDDetails.Find(data);
                    string copyNumber = dvd.NoOfCopy;
                    int cn = int.Parse(copyNumber);
                    int cnn = cn + 1;
                    copyNumber = cnn.ToString();
                    dvd.NoOfCopy = copyNumber;
                    db.Entry(dvd).State = EntityState.Modified;
                    db.SaveChanges();

                }


                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
