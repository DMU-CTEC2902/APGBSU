using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalumBSUAttempt2.Models;

namespace CalumBSUAttempt2.Controllers
{
    public class ActorLeagueTableController : Controller
    {
        private BSUMovieWebsiteContext db = new BSUMovieWebsiteContext();

        // GET: FilmLeagueTable
        public ActionResult Index(string sort)
        {
            if (String.IsNullOrEmpty(sort))
            {
                ViewBag.RatingSortPar = "Rating_Asc";
            }
            else
            {
                ViewBag.RatingSortPar = "Rating_Desc";
            }

            var actors = from actor in db.Actors select actor;

            switch (sort)
            {
                case "Rating_Asc":
                    actors = actors.OrderBy(actor => actor.Rating);
                    break;
                case "Rating_Desc":
                    actors = actors.OrderByDescending(actor => actor.Rating);
                    break;
            }
            return View(actors.ToList());
        }

            // GET: ActorLeagueTable/Details/5
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

        // GET: ActorLeagueTable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActorLeagueTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActorId,ActorImage,ActorName,ActorBio,ActorDOB,Rating")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: ActorLeagueTable/Edit/5
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

        // POST: ActorLeagueTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActorId,ActorImage,ActorName,ActorBio,ActorDOB,Rating")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: ActorLeagueTable/Delete/5
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

        // POST: ActorLeagueTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
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
