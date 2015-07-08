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
    public class AlertController : Controller
    {
        //
        // GET: /Alert/

        public ActionResult Index()
        {
            var db = new HefestoDevicesEntities();
            var alerts = db.Alerts.ToList();
            ViewBag.list = alerts;
            return View();
        }

/********************************************************************************************************************/
        public ActionResult Create(int id, int type)
        {
            var db = new HefestoDevicesEntities();
            Alerts alert = new Alerts();
            Device_Information device = new Device_Information();
            Alert_Types mess = new Alert_Types();
            //Variables used for obtain information to the mail
            mess = db.Alert_Types.Find(type);
            device = db.Device_Information.Find(id);

            //Creation of new alert
            alert.Alert_Device = id;
            alert.Alert_Type = type;
            alert.Alert_Opendate = DateTime.Now;
            alert.Alert_Isread = 0;

            db.Alerts.Add(alert);
            db.SaveChanges();

            //Creation of the message and maps location
            string message = "Report from: " + device.Device_Name + " about: " + mess.Alert_Description;
            message += "\r\n Location: \r\n";
            message += "http://maps.googleapis.com/maps/api/staticmap?center=" + device.Device_Lat.ToString() + "," + device.DEvice_Long.ToString() + "&zoom=15&size=600x300&maptype=roadmap&markers=color:blue%7Clabel:S%7C";
            message += device.Device_Lat.ToString() + "," + device.DEvice_Long.ToString() + "&sensor=false";

            //Creation of the mail's header
            string subject = "Alert from: " + device.Device_Name;
            string address = device.Device_Email;
            string email = "hefestoserver1@gmail.com";
            string password = "Hefestoserver050505";

            //Send Email  message
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

            //Shows the information of the device after create alert
            return RedirectToAction("Details","Device", new { id = id });
        }
/********************************************************************************************************************/
        public ActionResult Details(int id)
        {
            var db = new HefestoDevicesEntities();
            Alerts alert = new Alerts();
            alert = db.Alerts.Find(id);
            return View(alert);
        }

        public ActionResult ReadAlert(int id)
        {
            var db = new HefestoDevicesEntities();
            Alerts alert = new Alerts();
            alert = db.Alerts.Find(id);
            alert.Alert_Isread = 1;
            alert.Alert_Closedate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Details", "Alert", new { id = id }); 
        }

    }
}
