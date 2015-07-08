using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HefestoServer.Models;


namespace HefestoServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Select an option:";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
