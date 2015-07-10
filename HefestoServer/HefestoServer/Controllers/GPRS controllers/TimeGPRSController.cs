using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HefestoServer.Controllers.GPRS_controllers
{
    public class TimeGPRSController : Controller
    {
        //
        // GET: /TimeGPRS/

        public ActionResult Index()
        {
            return View();
        }
        public string Nowtime(int id)
        {
            string result = "";

            result = result + "dy" + DateTime.Now.Day.ToString();
            result = result + "mt" + DateTime.Now.Month.ToString();
            result = result + "yr" + DateTime.Now.Year.ToString();
            result = result + "hr" + DateTime.Now.Hour.ToString();
            result = result + "mn" + DateTime.Now.Minute.ToString()+"$\r\n";      

            return result;
        }

    }
}
