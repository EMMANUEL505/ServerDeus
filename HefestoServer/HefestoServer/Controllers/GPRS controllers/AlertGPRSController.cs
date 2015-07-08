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
    public class AlertGPRSController : Controller
    {
        //
        // GET: /AlertLV/

        public string Index()
        {
            string listresult = "";
            XMLalert result = new XMLalert();
            var db = new HefestoDevicesEntities();
            var alerts = db.Alerts.ToList();

            foreach (var alert in alerts)
            {
                result.Id = alert.Alert_Id;
                result.Name = alert.Device_Information.Device_Name;
                result.Alert = alert.Alert_Types.Alert_Description;
                result.Opendate = alert.Alert_Opendate;
                result.Closedate = alert.Alert_Closedate.ToString();

                listresult += result.XMLresult("AlertArray");
            }

            return listresult;
        }

        //
        // GET: /AlertLV/Details/5

        public string Details(int id)
        {
            string listresult = "";
            XMLalert result = new XMLalert();
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);

            var alerts = (from p in db.Alerts
                              where p.Device_Information.Device_Name.Contains(device.Device_Name)
                              select p).ToList();

            foreach (var alert in alerts)
            {
                result.Id = alert.Alert_Id;
                result.Name = alert.Device_Information.Device_Name;
                result.Alert = alert.Alert_Types.Alert_Description;
                result.Opendate = alert.Alert_Opendate;
                result.Closedate = alert.Alert_Closedate.ToString();

                listresult += result.XMLresult("AlertArray");
            }

            return listresult;
        }

        public string ReadAlert(int id)
        {
            var db = new HefestoDevicesEntities();
            Alerts alert = new Alerts();
            alert = db.Alerts.Find(id);
            if (alert.Alert_Isread == 0)
            {
                alert.Alert_Isread = 1;
                alert.Alert_Closedate = DateTime.Now;
                db.SaveChanges();
                return "OK";
            }

            else { return "ERROR"; }

        }

        public string Create(int id, int type)
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
            string email = "hefestoserver@gmail.com";
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
            return "OK";
        }
        
    }
}
