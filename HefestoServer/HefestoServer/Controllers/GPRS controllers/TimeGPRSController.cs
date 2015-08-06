using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HefestoServer.Models;

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
        public string Offtime(int id)
        {
            string result = "";
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);

            result = result + "hr" + device.Device_OffTime.Value.Hours.ToString();//DateTime.Now.Hour.ToString();
            result = result + "mn" + device.Device_OffTime.Value.Minutes.ToString() + "$\r\n"; //DateTime.Now.Minute.ToString() + "$\r\n";
            return result;
        }
        public string Ontime(int id)
        {
            string result = "";
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);

            result = result + "hr" + device.Device_OnTime.Value.Hours.ToString();//DateTime.Now.Hour.ToString();
            result = result + "mn" + device.Device_OnTime.Value.Minutes.ToString() + "$\r\n"; //DateTime.Now.Minute.ToString() + "$\r\n";
            return result;
        }

    }
}
