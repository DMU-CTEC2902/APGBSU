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
    public class FilmLeagueTableController : Controller
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

            var films = from film in db.Films select film;

            switch (sort)
            {
                case "Rating_Asc":
                    films = films.OrderBy(film => film.Rating);
                    break;
                case "Rating_Desc":
                    films = films.OrderByDescending(film => film.Rating);
                    break;
            }
            return View(films.ToList());


            /*
            var films = db.Films.Include(f => f.Genre);
            List<Film> filmList = films.ToList();
            List<Film> sortedFilmList = new List<Film>();

            while(filmList.Count != sortedFilmList.Count)
            {
                for (int i = 0; i < filmList.Count; i++)
                {
                    if (sortedFilmList.Count == 0)
                    {
                        sortedFilmList[0] = filmList[0];
                    }
                    for (int j = 0; j < sortedFilmList.Count; j++)
                    {
                        if (filmList[i].Rating > sortedFilmList[j].Rating)
                        {
                            Film tempFilm = sortedFilmList[j];
                            sortedFilmList[j] = filmList[i];
                            filmList[j] = filmList[j + 1];
                        }
                    }
                }
            }
            return View(sortedFilmList);
            */
        }

            // GET: FilmLeagueTable/Details/5
            public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: FilmLeagueTable/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
            return View();
        }

        // POST: FilmLeagueTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmId,FilmImage,FilmName,FilmDescription,Rating,ReleaseDate,FilmLength,GenreId")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", film.GenreId);
            return View(film);
        }

        // GET: FilmLeagueTable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", film.GenreId);
            return View(film);
        }

        // POST: FilmLeagueTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmId,FilmImage,FilmName,FilmDescription,Rating,ReleaseDate,FilmLength,GenreId")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", film.GenreId);
            return View(film);
        }

        // GET: FilmLeagueTable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: FilmLeagueTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Films.Find(id);
            db.Films.Remove(film);
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
