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
    public class clientContactDb
    {
        private AcomMvcContext db;
        public clientContactDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<clientContact>> GetAll()
        {
            try
            {
                List<clientContact> clientContacts = await db.clientContacts.Include(p => p.client).ToListAsync();
                return clientContacts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<clientContact> GetById(int? id)
        {
            if (id != 0 && id != null)
            {
                clientContact clientContact;
                try
                {
                    clientContact = await db.clientContacts.FindAsync(id);
                    return clientContact;
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

        public async Task<ICollection<clientContact>> GetAllByClientId(int? id)
        {
            if (id != 0 && id != null)
            {
                try
                {
                    List<clientContact> clientContacts;
                    clientContacts = await db.clientContacts.Where(p=>p.clientID==id).ToListAsync();
                    return clientContacts;
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

        public async Task<ICollection<clientContact>> GetAllByOfficeId(int? id)
        {
            if (id != 0 && id != null)
            {
                try
                {
                    List<clientContact> clientContacts;
                    clientContacts = await db.clientContacts.Where(p => p.clientOfficeID == id).ToListAsync();
                    return clientContacts;
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


        public async Task<clientContact> Add(clientContact clientContact)
        {
            try
            {
                db.clientContacts.Add(clientContact);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return clientContact;
        }

        public async Task<clientContact> Update(clientContact clientContact)
        {
            try
            {
                db.Entry<clientContact>(clientContact).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return clientContact;
        }

        public async Task<clientContact> Delete(int? id)
        {
            if (id != 0 && id != null)
            {
                clientContact clientContact;
                try
                {
                    clientContact = await db.clientContacts.FindAsync(id);
                    if (clientContact != null)
                    {
                        clientContact.annull = true;
                        await db.SaveChangesAsync();
                        return clientContact;
                    }
                    else
                    {
                        throw new Exception("Contatto non trovato");
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

        public void Dispose()
        {
            db.Dispose();
        }


    }
}