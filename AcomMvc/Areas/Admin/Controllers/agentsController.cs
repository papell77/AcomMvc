using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
//using System.Net;
//using System.Web;
using System.Web.Mvc;
using AcomMvc.Core.Domain;
using AcomMvc.Persistence;
using AcomMvc.Persistence.Repositories;


namespace AcomMvc.Areas.Admin.Controllers
{
    public class agentsController : Controller
    {
        private agentDb db = new agentDb();
        private userDb dbUsr = new userDb();

        // GET: Admin/agents
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/agents/GetJson
        public async Task<ActionResult> GetJson()
        {
            try
            {
                return Json(await db.GetAll(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Admin/agents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                return Json(await db.GetById(id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Admin/agents/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "ID,agentName,agentUserID,note,annull,createdBy,createdDate,updatedBy,updatedDate,rowvers")] agent agent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.Add(agent);
                }
                catch (Exception ex)
                {
                    return Json(new Exception(ex.Message), JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new Exception("Modello non valido"),JsonRequestBehavior.AllowGet);
            }

            return Json(agent, JsonRequestBehavior.AllowGet);
        }

        // POST: Admin/agents/Edit
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "ID,agentName,agentUserID,note,annull,createdBy,createdDate,updatedBy,updatedDate,rowvers")] agent agent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await db.Update(agent);
                }
                catch (Exception ex)
                {
                    return Json(new Exception(ex.Message), JsonRequestBehavior.AllowGet);
                }
                
            }
            else
            {
                return Json(new Exception("Modello non valido"), JsonRequestBehavior.AllowGet);
            }
            return Json(agent, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            //base.Dispose(disposing);
        }

        // POST: Admin/agents/Delete/5
        //[HttpPost, ActionName("Delete")]
        //public async Task<ActionResult> DeleteConfirmed(int? id)
        //{
        //    agent agent;
        //    try
        //    {
        //        agent = await db.Delete(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex.Message, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(agent, JsonRequestBehavior.AllowGet);
        //}

    }
}
