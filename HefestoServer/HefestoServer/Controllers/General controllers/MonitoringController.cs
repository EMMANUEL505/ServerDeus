using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HefestoServer.Models;

namespace HefestoServer.Controllers
{
    public class MonitoringController : Controller
    {
        //
        // GET: /Monitoring/

        public ActionResult Index()
        {
            var db = new HefestoDevicesEntities();
            var monitor = db.Monitor.ToList();

            monitor.OrderByDescending(Monitor => Monitor.Monitor_Device );
            ViewBag.list = monitor;
            return View();
        }

        //
        // GET: /Monitoring/Details/5

        public ActionResult Details(int id)
        {
            var db = new HefestoDevicesEntities();
            Device_Information device = new Device_Information();
            device = db.Device_Information.Find(id);
            ViewBag.devicename = device.Device_Name;

            ViewBag.monitoring = (from p in db.Monitor
                              where p.Device_Information.Device_Name.Contains(device.Device_Name)
                              select p).ToList();
            return View();
        }

        //
        // GET: /Monitoring/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Monitoring/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Monitoring/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Monitoring/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Monitoring/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Monitoring/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
