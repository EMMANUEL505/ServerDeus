using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HefestoServer.Models;

namespace HefestoServer.Controllers
{
    public class DeviceLVController : Controller
    {
        //
        // GET: /DeviceLV/
        public string Index()
        {
            string listresult="";
            XMLparser result = new XMLparser();
            var db = new HefestoDevicesEntities();
            var devices = db.Device_Information.ToList();

            foreach (var device in devices)
            {
                result.Name = device.Device_Name;
                result.Email = device.Device_Email;
                result.Zone = device.Device_Zone;

                result.Id = device.Device_Id;
                result.Lat = (float)device.Device_Lat;
                result.Long = (float)device.DEvice_Long;
                result.Mode = (int)device.Device_Mode;
                result.Status = (int)device.Device_Status;
                listresult += result.XMLresult("DeviceArray");
            }
            
            return listresult;
        }

        //
        // GET: /DeviceLV/Details/5

        public string Details(int id)
        {
            XMLparser  result= new XMLparser();

            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);

            result.Name = device.Device_Name;
            result.Email = device.Device_Email;
            result.Zone = device.Device_Zone;

            result.Id = device.Device_Id;
            result.Lat = (float) device.Device_Lat;
            result.Long =(float) device.DEvice_Long;
            result.Mode =(int) device.Device_Mode;
            result.Status = (int)device.Device_Status;

            return result.XMLresult("Value");
        }

        //
        // GET: /DeviceLV/Create?name=&lat=&lon=&mode=&status=&zone=&email=

        public string Create(string name, float lat, float lon, int mode, int status, string zone, string email)
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
            return "OK";
        }

        //
        // POST: /DeviceLV/Edit
        public string Edit(int id, string name, float lat, float lon, int mode, int status, string zone, string email)
        {
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);

            device.Device_Name = name;
            device.Device_Lat = lat;
            device.DEvice_Long = lon;
            device.Device_Mode = mode;
            device.Device_Status = status;
            device.Device_Zone = zone;
            device.Device_Email = email;

            db.SaveChanges();

            return "OK";
        }


        //GET: /DeviceLV/Control/?id=&mode=&status=
        public string Control(int id, int mode, int status)
        {
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);

            device.Device_Mode = mode;
            device.Device_Status = status;
            db.SaveChanges();

            return "OK";
        }

        public string GetMode(int id)
        {
            try
            {
                var db = new HefestoDevicesEntities();
                Device_Information device = new Device_Information();
                device = db.Device_Information.Find(id);

                return "<" + device.Device_Mode.ToString() + ">";
            }
            catch
            {
                return "ERROR";
            }
        }

        public string GetStatus(int id)
        {
            try
            {
                var db = new HefestoDevicesEntities();
                Device_Information device = new Device_Information();
                device = db.Device_Information.Find(id);

                return "<"+device.Device_Status.ToString()+">";
            }
            catch
            {
                return "ERROR";
            }
        }

    }
}
