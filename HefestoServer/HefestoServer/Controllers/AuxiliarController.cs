using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HefestoServer.Models;


namespace HefestoServer.Controllers
{
    public class AuxiliarController : Controller
    {
        //
        // GET: /Auxiliar/

        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: /Auxiliar/

        public ActionResult Showlocation(float lat, float lon)
        {
            ViewBag.lati = lat;
            ViewBag.lon=lon;

            return PartialView();
        }
        //
        // GET: /Auxiliar/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Auxiliar/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Auxiliar/Create

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
        // GET: /Auxiliar/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Auxiliar/Edit/5

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
        // GET: /Auxiliar/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Auxiliar/Delete/5

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
        public ActionResult DeviceLocation(int id)
       {
           /*var db = new HefestoDevicesEntities();
           Device_Information device = new Device_Information();
           device = db.Device_Information.Find(id);
           float lat = (float)device.Device_Lat;
           float lon = (float)device.DEvice_Long;

           ViewBag.lati = lat;
           ViewBag.lon=lon;*/
    
           ViewBag.lati = 28.633839;
           ViewBag.lon = -106.077082;
           return PartialView();
       }
        public ActionResult SaveCircuit(int id)
        {
            /*var db = new HefestoDevicesEntities();
             Device_Information device = new Device_Information();
             device = db.Device_Information.Find(id);
             float lat = (float)device.Device_Lat;
             float lon = (float)device.DEvice_Long;

             ViewBag.lati = lat;
             ViewBag.lon=lon;*/

            ViewBag.lati = 28.633839;
            ViewBag.lon = -106.077082;
            return PartialView();
        }

    }
}
