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
    public class DiscussionInfoesController : Controller
    {
        private BSUMovieWebsiteContext db = new BSUMovieWebsiteContext();

        // GET: DiscussionInfoes
        public ActionResult Index()
        {
            var discussionInfoes = db.DiscussionInfoes.Include(d => d.Discussion);
            return View(discussionInfoes.ToList());
        }

        // GET: DiscussionInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscussionInfo discussionInfo = db.DiscussionInfoes.Find(id);
            if (discussionInfo == null)
            {
                return HttpNotFound();
            }
            return View(discussionInfo);
        }

        // GET: DiscussionInfoes/Create
        public ActionResult Create()
        {
            ViewBag.DiscussionId = new SelectList(db.Discussions, "DiscussionId", "Name");
            return View();
        }

        // POST: DiscussionInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiscussionInfoId,Message,DiscussionId,User")] DiscussionInfo discussionInfo)
        {
            if (ModelState.IsValid)
            {
                db.DiscussionInfoes.Add(discussionInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiscussionId = new SelectList(db.Discussions, "DiscussionId", "Name", discussionInfo.DiscussionId);
            return View(discussionInfo);
        }

        // GET: DiscussionInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscussionInfo discussionInfo = db.DiscussionInfoes.Find(id);
            if (discussionInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiscussionId = new SelectList(db.Discussions, "DiscussionId", "Name", discussionInfo.DiscussionId);
            return View(discussionInfo);
        }

        // POST: DiscussionInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiscussionInfoId,Message,DiscussionId,User")] DiscussionInfo discussionInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discussionInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiscussionId = new SelectList(db.Discussions, "DiscussionId", "Name", discussionInfo.DiscussionId);
            return View(discussionInfo);
        }

        // GET: DiscussionInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscussionInfo discussionInfo = db.DiscussionInfoes.Find(id);
            if (discussionInfo == null)
            {
                return HttpNotFound();
            }
            return View(discussionInfo);
        }

        // POST: DiscussionInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiscussionInfo discussionInfo = db.DiscussionInfoes.Find(id);
            db.DiscussionInfoes.Remove(discussionInfo);
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
