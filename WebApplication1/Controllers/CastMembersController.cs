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
    public class CastMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CastMembers
        public ActionResult Index()
        {
            var castMembers = db.CastMembers.Include(c => c.Actors).Include(c => c.DVDDetails);
            return View(castMembers.ToList());
        }

        // GET: CastMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMember castMember = db.CastMembers.Find(id);
            if (castMember == null)
            {
                return HttpNotFound();
            }
            return View(castMember);
        }

        // GET: CastMembers/Create
        public ActionResult Create()
        {
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName");
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title");
            return View();
        }

        // POST: CastMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DVDId,ActorId")] CastMember castMember)
        {
            if (ModelState.IsValid)
            {
                db.CastMembers.Add(castMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", castMember.ActorId);
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", castMember.DVDId);
            return View(castMember);
        }

        // GET: CastMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMember castMember = db.CastMembers.Find(id);
            if (castMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", castMember.ActorId);
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", castMember.DVDId);
            return View(castMember);
        }

        // POST: CastMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DVDId,ActorId")] CastMember castMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(castMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName", castMember.ActorId);
            ViewBag.DVDId = new SelectList(db.DVDDetails, "DVDId", "Title", castMember.DVDId);
            return View(castMember);
        }

        // GET: CastMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMember castMember = db.CastMembers.Find(id);
            if (castMember == null)
            {
                return HttpNotFound();
            }
            return View(castMember);
        }

        // POST: CastMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CastMember castMember = db.CastMembers.Find(id);
            db.CastMembers.Remove(castMember);
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
