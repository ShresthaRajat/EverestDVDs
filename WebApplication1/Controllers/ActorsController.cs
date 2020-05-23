using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ActorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Actors
        public ActionResult Index()
        {
            return View(db.Actors.ToList());
        }

        // GET: Actors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor actor)
        {
            string fileName = Path.GetFileNameWithoutExtension(actor.ImageFile.FileName);
            string extention = Path.GetExtension(actor.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            actor.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            actor.ImageFile.SaveAs(fileName);
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor actor)
        {
            string fileName = Path.GetFileNameWithoutExtension(actor.ImageFile.FileName);
            string extention = Path.GetExtension(actor.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            actor.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            actor.ImageFile.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor path = db.Actors.Where(x => x.ActorId == id).FirstOrDefault();
            string imagePath = path.ImagePath;
            string filePath = Server.MapPath(imagePath);
            Boolean exist = false;
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                exist = true;
            }
            if (exist == true)
            {
                Actor actor = db.Actors.Find(id);
                db.Actors.Remove(actor);
                db.SaveChanges();
            }
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
