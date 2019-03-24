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
    public class DirectorLeagueTableController : Controller
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

            var directors = from Director in db.Directors select Director;

            switch (sort)
            {
                case "Rating_Asc":
                    directors = directors.OrderBy(film => film.Rating);
                    break;
                case "Rating_Desc":
                    directors = directors.OrderByDescending(film => film.Rating);
                    break;
            }
            return View(directors.ToList());
        }

            // GET: DirectorLeagueTable/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // GET: DirectorLeagueTable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectorLeagueTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectorId,DirectorImage,DirectorName,DirectorBio,DirectorDOB,Rating")] Director director)
        {
            if (ModelState.IsValid)
            {
                db.Directors.Add(director);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(director);
        }

        // GET: DirectorLeagueTable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: DirectorLeagueTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectorId,DirectorImage,DirectorName,DirectorBio,DirectorDOB,Rating")] Director director)
        {
            if (ModelState.IsValid)
            {
                db.Entry(director).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(director);
        }

        // GET: DirectorLeagueTable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: DirectorLeagueTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Director director = db.Directors.Find(id);
            db.Directors.Remove(director);
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
