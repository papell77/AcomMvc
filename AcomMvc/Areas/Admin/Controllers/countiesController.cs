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
    public class countiesController : Controller
    {
        private countyDb db = new countyDb();

        // GET: Admin/counties
        public ActionResult Index()
        {
            try
            {
                return View(db.GetAll());
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        // GET: Admin/counties/GetJson
        public ActionResult GetJson()
        {
            try
            {
                return Json(db.GetAll(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: Admin/counties/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            county county;
            try
            {
                county = await db.GetById(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            } 
            
            if (county == null)
            {
                return HttpNotFound();
            }
            return View(county);
        }

        // GET: Admin/counties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/counties/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,countyName,countySign,note,annull,createdBy,createdDate,updatedBy,updatedDate,rowvers")] county county)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.Add(county);
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["success"] = "Provincia inserita";
                return RedirectToAction("Index");
            }
            return View(county);
        }

        // GET: Admin/counties/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            county county;
            try
            {
                county = await db.GetById(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
            if (county == null)
            {
                return HttpNotFound();
            }
            return View(county);
        }

        // POST: Admin/counties/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,countyName,countySign,note,annull,createdBy,createdDate,updatedBy,updatedDate,rowvers")] county county)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.Update(county);
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["success"] = "Provincia modificata";
                return RedirectToAction("Index");
            }
            return View(county);
        }

        // GET: Admin/counties/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    county county = await db.counties.FindAsync(id);
        //    if (county == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(county);
        //}

        // POST: Admin/counties/Delete/5
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
            TempData["success"] = "Provincia disattivata";
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
