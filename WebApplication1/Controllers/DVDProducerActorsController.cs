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
    public class DVDProducerActorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DVDProducerActors
        public ActionResult Index()
        {

            List<CastMember> castMembers = db.CastMembers.ToList();
            List<DVDProducer> dvdproducers = db.DVDProducers.ToList();

            var data = from c in castMembers
                       join p in dvdproducers on c.DVDId equals p.DVDId
                       select new DVDProducerActors
                       {
                           castMember=c,
                           dVDProducer=p
                       };
            var sorteddata = data.OrderBy(t => t.castMember.Actors.LastName).OrderBy(d => d.castMember.DVDDetails.DateAdded).ToList();



            return View(sorteddata);



        }

        
    }
}
