using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;

namespace Knowledge_Garden.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Flowers");
            }
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

        public ActionResult Debug()
        {
            ViewBag.Message = User.Identity.Name;

            return View();
        }
    }
}