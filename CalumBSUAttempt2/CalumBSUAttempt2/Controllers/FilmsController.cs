using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalumBSUAttempt2.Models;
using Microsoft.AspNet.Identity;

namespace CalumBSUAttempt2.Controllers
{
    public class FilmsController : Controller
    {
        private BSUMovieWebsiteContext db = new BSUMovieWebsiteContext();

        // GET: Films
        public ActionResult Index()
        {
            ViewBag.userId = User.Identity.GetUserId();
            var films = db.Films.Include(f => f.Genre);
            return View(films.ToList());
        }

        public ActionResult FilmComment(int? id)
        {
            ViewBag.filmId = id;
            var filmComments = db.FilmComments.Include(f => f.Film);
            return View(filmComments.ToList());
        }



        // GET: Films/Details/5
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


        // GET: Films/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmId,FilmImage,FilmName,FilmDescription,Rating,ReleaseDate,FilmLength,GenreId")] Film film)
        {
            if (ModelState.IsValid)
            {
                film.User = User.Identity.GetUserId();
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", film.GenreId);
            return View(film);
        }

        // GET: FilmComments/Create
        public ActionResult CommentCreate()
        {
            ViewBag.FilmId = new SelectList(db.Films, "FilmId", "FilmImage");
            return View();
        }

        // POST: FilmComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentCreate([Bind(Include = "FilmCommentId,FilmId,Comment,User")] FilmComment filmComment)
        {
            if (ModelState.IsValid)
            {
                db.FilmComments.Add(filmComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmId = new SelectList(db.Films, "FilmId", "FilmImage", filmComment.FilmId);
            return View(filmComment);
        }

        // GET: Films/Edit/5
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

        // POST: Films/Edit/5
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

        // GET: FilmComments/Edit/5
        public ActionResult CommentEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmComment filmComment = db.FilmComments.Find(id);
            if (filmComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmId = new SelectList(db.Films, "FilmId", "FilmImage", filmComment.FilmId);
            return View(filmComment);
        }

        // POST: FilmComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentEdit([Bind(Include = "FilmCommentId,FilmId,Comment,User")] FilmComment filmComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmId = new SelectList(db.Films, "FilmId", "FilmImage", filmComment.FilmId);
            return View(filmComment);
        }

        // GET: Films/Delete/5
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

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Films.Find(id);
            db.Films.Remove(film);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: FilmComments/Delete/5
        public ActionResult CommentDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmComment filmComment = db.FilmComments.Find(id);
            if (filmComment == null)
            {
                return HttpNotFound();
            }
            return View(filmComment);
        }

        // POST: FilmComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult CommentDeleteConfirmed(int id)
        {
            FilmComment filmComment = db.FilmComments.Find(id);
            db.FilmComments.Remove(filmComment);
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
