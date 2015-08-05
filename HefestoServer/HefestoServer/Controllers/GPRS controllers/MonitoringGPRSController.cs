using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HefestoServer.Models;
namespace HefestoServer.Controllers
{
    public class MonitoringGPRSController : Controller
    {
        //
        // GET: /MonitoringLV/

        public string Index()
        {
            string listresult = "";
            XMLmonitoring result = new XMLmonitoring();
            var db = new HefestoDevicesEntities();
            var monitors = db.Monitor.ToList();

            foreach (var monitor in monitors)
            {
                result.Id = monitor.Monitor_Id;
                result.Name = monitor.Device_Information.Device_Name;
                result.Date = monitor.Monitor_Date.ToString();
                result.Current = (float)monitor.Monitor_Current;
                result.Voltage = (float)monitor.Monitor_Voltage;

                listresult += result.XMLresult("Array2");
            }

            return listresult;
        }

        //
        // GET: /MonitoringLV/Details/5

        public string Details(int id)
        {
            string listresult = "";
            XMLmonitoring result = new XMLmonitoring();
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);

            var monitors = (from p in db.Monitor 
                          where p.Device_Information.Device_Name.Contains(device.Device_Name)
                          select p).ToList();

            foreach (var monitor in monitors)
            {
                result.Id = monitor.Monitor_Id;
                result.Name = monitor.Device_Information.Device_Name;
                result.Date = monitor.Monitor_Date.ToString();
                result.Current = (float)monitor.Monitor_Current;
                result.Voltage = (float)monitor.Monitor_Voltage;

                listresult += result.XMLresult("Array2");
            }

            return listresult;
        }

        //
        // GET: /MonitoringLV/Create

        public string Create(int id,int status,float current, float voltage)
        {
            try
            {
                var db = new HefestoDevicesEntities();
                Monitor mon = new Monitor();

                mon.Monitor_Device = id;
                mon.Monitor_Date = DateTime.Now;
                mon.Monitor_Status = status;
                mon.Monitor_Current = current;
                mon.Monitor_Voltage = voltage;
                db.Monitor.Add(mon);
                db.SaveChanges();

                return "OK$";
            }
            catch
            {
                return "ERROR";
            }
        }
        public string Create2(int id, int status, float current, float voltage,float var1,float var2)
        {
            try
            {
                var db = new HefestoDevicesEntities();
                Monitor mon = new Monitor();

                mon.Monitor_Device = id;
                mon.Monitor_Date = DateTime.Now;
                mon.Monitor_Status = status;
                mon.Monitor_Current = Math.Round(current,2);
                mon.Monitor_Voltage = Math.Round(voltage,2);
                mon.Monitor_Var1 = Math.Round(var1,2);
                mon.Monitor_Var2 = Math.Round(var2, 2);
                db.Monitor.Add(mon);
                db.SaveChanges();

                return "OK$";
            }
            catch
            {
                return "ERROR";
            }
        } 


    }
}
