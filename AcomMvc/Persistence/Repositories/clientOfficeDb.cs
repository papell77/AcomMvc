using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcomMvc.Core.Domain;
using Microsoft.AspNet.Identity;

namespace AcomMvc.Persistence.Repositories
{
    public class clientOfficeDb
    {
        private AcomMvcContext db;
        public clientOfficeDb()
        {
            db = new AcomMvcContext();
        }

        //L'oggetto da ritornare è iQueryable perchè nel controller e nella view utilizzerò un modello specifico per visualizzare le nested entities
        public IQueryable<clientOffice> GetAll()
        {
            try
            {
                IQueryable<clientOffice> clientOffices = db.clientOffices.Include(p=>p.client).Include(p=>p.county).Include(p=>p.city);
                return clientOffices;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //L'oggetto da ritornare è iQueryable perchè nel controller e nella view utilizzerò un modello specifico per visualizzare le nested entities
        public IQueryable<clientOffice> GetById(int? id)
        {

            if (id != 0 && id != null)
            {
                try
                {
                    IQueryable<clientOffice> clientOffice = db.clientOffices.Include(p => p.city).Include(p => p.client).Include(p => p.county).Where(p => p.ID == id);
                    return clientOffice;
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

        public async Task<clientOffice> Add(clientOffice clientOffice)
        {
            try
            {
                db.clientOffices.Add(clientOffice);
                await db.SaveChangesAsync();
                return clientOffice;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<clientOffice> Update(clientOffice clientOffice)
        {
            try
            {
                db.Entry<clientOffice>(clientOffice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return clientOffice;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<clientOffice> Delete(int? id)
        {
            if (id != 0 && id != null)
            {
                clientOffice clientOffice;
                try
                {
                    clientOffice = await db.clientOffices.FindAsync(id);
                    if (clientOffice != null)
                    {
                        clientOffice.annull = true;
                        await db.SaveChangesAsync();
                        return clientOffice;
                    }
                    else
                    {
                        throw new Exception("Filiale non trovata");
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
        public IQueryable<clientOffice> Search(string ragSociale, string officeName, int? countyId, int? cityId, int? agentId, int? canalId, string piva, string phone)
        {
            IQueryable<clientOffice> query;
            try
            {
                query = db.clientOffices.Include(p => p.client).Include(p => p.city).Include(p => p.county);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (ragSociale != null)
            {
                query = query.Where(p => p.client.clientRagioneSociale.Contains(ragSociale));
            }

            if (officeName != null)
            {
                query = query.Where(p => p.clientOfficeName.Contains(officeName));
            }

            if (countyId != 0 && countyId != null)
            {
                query = query.Where(p => p.countyID == countyId);
            }

            if (cityId != 0 && cityId != null)
            {
                query = query.Where(p => p.cityID == cityId);
            }

            if (agentId != 0 && agentId != null)
            {
                query = query.Where(p => p.client.agentID == agentId);
            }

            if (canalId != 0 && canalId != null)
            {
                query = query.Where(p => p.client.canalID == canalId);
            }

            if (piva != null)
            {
                query = query.Where(p => p.client.clientPiva.Contains(piva));
            }

            if (phone != null)
            {
                query = query.Where(p => p.clientOfficePhone.Contains(phone));
            }

           return query;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}