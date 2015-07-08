using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HefestoServer.Models;
using System.Net.Mail;
using System.Net;


namespace HefestoServer.Controllers
{
    public class DeviceController : Controller
    {

        /********************************************************************************************************************/
        //
        // GET: /Device/
        public ActionResult Index()
        {
            var db = new HefestoDevicesEntities();
            var devices = db.Device_Information.ToList();
            ViewBag.list = devices;

            return View();
        }

/********************************************************************************************************************/
        //
        // GET: /Device/New
        public ActionResult New()
        {
            return View();
        }

/********************************************************************************************************************/
        [HttpPost]
        public ActionResult  New(Device model)
        {
            if (ModelState.IsValid)
            {
                var db = new HefestoDevicesEntities();
                Device_Information device = new Device_Information();

                device.Device_Name = model.Device_Name ;
                device.Device_Lat = model.Device_Lat ;
                device.DEvice_Long = model.DEvice_Long;
                device.Device_Mode = model.Device_Mode ;
                device.Device_Status = model.Device_Status;
                device.Device_Email = model.Device_Email ;
                device.Device_Zone = model.Device_Zone;

                db.Device_Information.Add(device);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = device.Device_Id });
            }

            // If we got this far, something failed, redisplay form
            return View("New");
        }


/********************************************************************************************************************/
        //
        // GET: /Device/Details/5
        public ActionResult  Details(int id)
        {
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device=db.Device_Information.Find(id);
            ViewBag.device = device;
            string maps="http://maps.googleapis.com/maps/api/staticmap?center=" + device.Device_Lat.ToString() + "," + device.DEvice_Long.ToString() + "&zoom=15&size=600x300&maptype=roadmap&markers=color:blue%7Clabel:S%7C";
            maps+= device.Device_Lat.ToString() + "," + device.DEvice_Long.ToString() + "&sensor=false";

            ViewBag.maps = maps;
            ViewBag.alerts = (from p in db.Alerts
                         where p.Device_Information.Device_Name.Contains(device.Device_Name ) 
                         select p).ToList();
    
            return View();

        }

/********************************************************************************************************************/
        //
        // GET: /Device/Create
        public ActionResult Create(string name, float lat, float lon, int mode, int status, string zone,string email)

        {
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();

            device.Device_Name = name;
            device.Device_Lat = lat;
            device.DEvice_Long = lon;
            device.Device_Mode = mode;
            device.Device_Status = status;
            device.Device_Zone = zone;
            device.Device_Email = email;

            db.Device_Information.Add(device);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = device.Device_Id  });
            //return View();
        }

/********************************************************************************************************************/
        public ActionResult Changemode(int id, int mode, int status)
        {
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);
            device.Device_Mode = mode;
            device.Device_Status = status;
            db.SaveChanges();

            return RedirectToAction("Details", new { id = device.Device_Id });
            //return View();

        }

/********************************************************************************************************************/
        //
        // GET: /Device/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);
            
            return View(device);
        }

        [HttpPost]
        public ActionResult Edit(Device model)

            {

                var db = new HefestoDevicesEntities();
                Device_Information device = new Device_Information();
                device = db.Device_Information.Find(model.Device_Id);

          if (ModelState.IsValid)
            {
                device.Device_Name = model.Device_Name ;
                device.Device_Lat = model.Device_Lat ;
                device.DEvice_Long = model.DEvice_Long;
                device.Device_Mode = model.Device_Mode ;
                device.Device_Status =model.Device_Status ;
                device.Device_Email = model.Device_Email ;
                device.Device_Zone = model.Device_Zone;

                db.SaveChanges();

                return RedirectToAction("Details", new { id = device.Device_Id });
            }

            // If we got this far, something failed, redisplay form
            return View(device);

            }

/********************************************************************************************************************/
        //
        // GET: /Device/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);
           

            var alerts = (from p in db.Alerts
                              where p.Device_Information.Device_Name.Contains(device.Device_Name)
                              select p).ToList();
            if (alerts.Count() > 0)
            {
                foreach (var alert in alerts)
                {
                    db.Alerts.Remove(alert);
                }
            }

            var monitor = (from p in db.Monitor
                          where p.Device_Information.Device_Name.Contains(device.Device_Name)
                          select p).ToList();
            if (monitor.Count() > 0)
            {
                foreach (var mon in monitor)
                {
                    db.Monitor.Remove(mon);
                }
            }

            
            db.Device_Information.Remove(device );
            db.SaveChanges();

            return RedirectToAction("Index");
            //return View();
        }
/********************************************************************************************************************/
        public string Sendmail(string address, string subject, string message)
        {
            string email = "hefestoserver@gmail.com";
            string password = "Hefestoserver050505";

            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);

            msg.From = new MailAddress(email);
            msg.To.Add(new MailAddress(address));
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = true;

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);

            return "Email send to :"+address ;
        }

/********************************************************************************************************************/
  
    }

}
