using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcomMvc.Core.Domain;
using AcomMvc.Persistence;
using AcomMvc.Persistence.Repositories;

namespace AcomMvc.Areas.Admin.Controllers
{
    public class citiesController : Controller
    {
        private cityDb db = new cityDb();
        private countyDb dbCounty = new countyDb();

        // GET: Admin/cities
        public async Task<ActionResult> Index(int id)
        {
            return Json(await db.GetByCountyId(id), JsonRequestBehavior.AllowGet);
        }


        // GET: Admin/cities/GetJson
        public async Task<ActionResult> GetJson()
        {
            try
            {
                return Json(await db.GetAll(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET: Admin/cities/GetJsonByCountyId
        public async Task<ActionResult> GetJsonByCountyId(int? id)
        {
            try
            {
                return Json(await db.GetByCountyId(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        // GET: Admin/cities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            city city;
            try
            {
                city = await db.GetById(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Admin/cities/Create
        public ActionResult Create()
        {
            ViewBag.countyID = dbCounty.GetAllNotNull();
            return View();
        }

        // POST: Admin/cities/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,cityName,cap,countyID,note,annull,createdBy,createdDate,updatedBy,updatedDate,rowvers")] city city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.Add(city);
                }
                catch (Exception ex)
                {
                    TempData["error"] =ex.Message;
                    return RedirectToAction("Index");
                }

                TempData["success"] = "Città inserita";
                return RedirectToAction("Index");
            }

            ViewBag.countyID = dbCounty.GetAllNotNull();
            TempData["error"] = "Errore nel modello";
            return View(city);
        }

        // GET: Admin/cities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            city city;
            try
            {
                city = await db.GetById(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }

            if (city == null)
            {
                return HttpNotFound();
            }

            ViewBag.countyID = dbCounty.GetAllNotNull();
            return View(city);
        }

        // POST: Admin/cities/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,cityName,cap,countyID,note,annull,createdBy,createdDate,updatedBy,updatedDate,rowvers")] city city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.Update(city);
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["success"] = "Città modificata";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Errore nel modello";
            ViewBag.countyID = dbCounty.GetAllNotNull();
            return View(city);
        }

        // GET: Admin/cities/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    city city = await db.cities.FindAsync(id);
        //    if (city == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(city);
        //}

        // POST: Admin/cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await db.Delete(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            TempData["success"] = "Città disattivata";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            //base.Dispose(disposing);
        }
    }
}
