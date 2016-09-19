using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using AcomMvc.Core.Domain;
using AcomMvc.Persistence.Repositories;
using Newtonsoft.Json;

namespace AcomMvc.Areas.Utente.Controllers
{
    public class clientController : Controller
    {
        private clientDb db=new clientDb();
        
        // GET: Utente/client
        public async Task<ActionResult> Index()
        {
            List<client> clients;
            try
            {
                clients = await db.GetAll().ToListAsync();
            }
            catch (Exception ex)
            {
                TempData["error"]=ex.Message;
                return View();
            }
            return View(clients);
        }

        public ActionResult GetClientsJson()
        {
            List<client> clients;
            string jsonClients;
            try
            {
                clients = db.GetAll().ToList();
                jsonClients = JsonConvert.SerializeObject(clients, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling=ReferenceLoopHandling.Ignore});
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(jsonClients, JsonRequestBehavior.AllowGet);
        }

        // GET: Utente/client/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            client client;
            try
            {
                client = await db.GetById(id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
            
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // GET: Utente/client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utente/client/Create
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

        // GET: Utente/client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Utente/client/Edit/5
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

        // GET: Utente/client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Utente/client/Delete/5
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetClients(string codice, string ragSociale, int? countyId, int? cityId, int? agentId, int? canalId, string piva, string phone, string sortOrder)
        {

            if (string.IsNullOrEmpty(codice) &&
                    string.IsNullOrEmpty(ragSociale) &&
                    !countyId.HasValue &&
                    !cityId.HasValue &&
                    !agentId.HasValue &&
                    !canalId.HasValue &&
                    String.IsNullOrEmpty(piva) &&
                    string.IsNullOrEmpty(phone) )
            {
                return PartialView();
            };

            try
            {
                var query = db.Search(codice, ragSociale, countyId, cityId, agentId, canalId, piva, phone);
                List<client> clients = query.ToList();
                //if (clients.Count==0)
                //{
                //    Response.Write("<script>alert('Nessun risultato');</script>");
                //    return PartialView();
                //}
                return PartialView(clients);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script>");
                return PartialView();
            }

        }
    }
}
