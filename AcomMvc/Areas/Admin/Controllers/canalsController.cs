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
    public class canalsController : Controller
    {
        private canalDb db = new canalDb();
        
        // GET: Admin/canals
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await db.GetAll());
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }            
        }

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

        // GET: Admin/canals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            canal canal;
            try
            {
                canal = await db.GetById(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            if (canal == null)
            {
                return HttpNotFound();
            }
            return View(canal);
        }

        // GET: Admin/canals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/canals/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,canalCode,canalDesc,note,annull,createdBy,createdDate,updatedBy,updatedDate,rowvers")] canal canal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.Add(canal);
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["success"] = "Canale inserito";
                return RedirectToAction("Index");
            }
            return View(canal);
        }

        // GET: Admin/canals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            canal canal;
            try
            {
                canal = await db.GetById(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            if (canal == null)
            {
                return HttpNotFound();
            }
            return View(canal);
        }

        // POST: Admin/canals/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,canalCode,canalDesc,note,annull,createdBy,createdDate,updatedBy,updatedDate,rowvers")] canal canal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.Update(canal);
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("Index");
                }
                TempData["success"] = "Canale modificato";
                return RedirectToAction("Index");
            }
            return View(canal);
        }

        // GET: Admin/canals/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    canal canal = await db.canals.FindAsync(id);
        //    if (canal == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(canal);
        //}

        // POST: Admin/canals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                canal canal = await db.Delete(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            TempData["success"] = "Canale disattivato";
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
