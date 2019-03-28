using CalumBSUAttempt2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalumBSUAttempt2.Controllers
{
    public class HomeController : Controller
    {
        private BSUMovieWebsiteContext db = new BSUMovieWebsiteContext();

        public ActionResult Index()
        {
            return View(db.Films.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}