using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AcomMvc.Core.Domain;
using Microsoft.AspNet.Identity;

namespace AcomMvc.Persistence.Repositories
{
    public class clientDb
    {
        private AcomMvcContext db;
        public clientDb()
        {
            db = new AcomMvcContext();
        }

        //L'oggetto da ritornare è iQueryable perchè nel controller e nella view utilizzerò un modello specifico per visualizzare le nested entities
        public IQueryable<client> GetAll()
        {
            try
            {
                var clients = db.clients.Include(p=>p.county).Include(p => p.city).Include(p => p.agent);
                //var clients = db.clients;
                return clients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //L'oggetto da ritornare è iQueryable perchè nel controller e nella view utilizzerò un modello specifico per visualizzare le nested entities
        public IQueryable<client> GetById(int? id)
        {
            if (id != 0 && id != null)
            {
                try
                {
                    var client = db.clients.Include(p => p.agent).Include(p => p.canal).Include(p => p.city).Include(p => p.county).Include(p => p.payment).Include(p => p.shipment).Where(p => p.ID == id);

                    return client;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("Formato della richiesta errato");
            }
        }

        public async Task<client> Add(client client)
        {
            try
            {
                db.clients.Add(client);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return client;
        }

        public async Task<client> Update(client client)
        {
            try
            {
                db.Entry<client>(client).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return client;
        }

        public async Task<client> Delete(int? id)
        {
            if (id != 0 && id != null)
            {
                client client;
                try
                {
                    client = await db.clients.FindAsync(id);
                    if (client != null)
                    {
                        client.annull = true;
                        await db.SaveChangesAsync();
                        return client;
                    }
                    else
                    {
                        throw new Exception("Cliente non trovato");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("Formato della richiesta errato");
            }
        }

        //L'oggetto da ritornare è iQueryable perchè nel controller e nella view utilizzerò un modello specifico per visualizzare le nested entities
        public IQueryable<client> Search(string codice, string ragSociale, int? countyId, int? cityId, int? agentId, int? canalId, string piva, string phone)
        {
            IQueryable<client> query;

            try
            {
                query = db.clients.Include(p => p.county).Include(p => p.city).Include(p => p.agent).Include(p => p.canal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (codice != null && codice!=string.Empty)
            {
                query = query.Where(p => p.clientCode.Contains(codice));
            }

            if (ragSociale != null && ragSociale!=string.Empty)
            {
                query = query.Where(p => p.clientRagioneSociale.Contains(ragSociale));
            }

            if (countyId.HasValue)
            {
                query = query.Where(p => p.countyID == countyId);
            }

            if (cityId.HasValue)
            {
                query = query.Where(p => p.cityID == cityId);
            }

            if (agentId.HasValue)
            {
                query = query.Where(p => p.agentID == agentId);
            }

            if (canalId.HasValue)
            {
                query = query.Where(p => p.canalID == canalId);
            }

            if (piva != null && piva!=string.Empty)
            {
                query = query.Where(p => p.clientPiva.Contains(piva));
            }

            if (phone != null && phone!=string.Empty)
            {
                query = query.Where(p => p.clientPhone.Contains(phone));
            }

            return query;
        }

        public void Dispose()
        {
            db.Dispose();
        }

       

    }
}