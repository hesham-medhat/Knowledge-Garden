using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Knowledge_Garden.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = Knowledge_Garden.Models.ApplicationInformation.ShortDescription;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = Knowledge_Garden.Models.ApplicationInformation.Credits;

            return View();
        }
    }
}