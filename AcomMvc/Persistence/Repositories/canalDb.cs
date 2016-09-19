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
    public class canalDb
    {
        private AcomMvcContext db;
        private string usr;

        public canalDb()
        {
            db = new AcomMvcContext();
            usr = HttpContext.Current.User.Identity.GetUserName();
        }

        public async Task<ICollection<canal>> GetAll()
        {
            try
            {
                List<canal> canals= await db.canals.OrderBy(p=>p.canalCode).ToListAsync();
                return canals;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<canal>> GetAllNotNull()
        {
            try
            {
                List<canal> canals = await db.canals.Where(p=>p.annull==false).ToListAsync();
                return canals;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<canal> GetById(int? id)
        {
            if (id != 0 && id != null)
            {
                try
                {
                    canal canal = await db.canals.FindAsync(id);
                    return canal;
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

        public async Task<canal> Add(canal canal)
        {
            try
            {
                canal.createdBy = usr;
                canal.createdDate = System.DateTime.Today;
                db.canals.Add(canal);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return canal;
        }

        public async Task<canal> Update(canal canal)
        {
            try
            {
                canal.updatedBy = usr;
                canal.updatedDate = System.DateTime.Today;
                db.Entry<canal>(canal).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return canal;
        }

        //Record non cancellato, set annull = true
        public async Task<canal> Delete(int? id)
        {
            if (id != 0 && id != null)
            {
                canal canal;
                try
                {
                    canal = await db.canals.FindAsync(id);
                    if (canal != null)
                    {
                        canal.updatedBy = usr;
                        canal.updatedDate = System.DateTime.Today;
                        canal.annull = true;
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Canale non trovato");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return canal;
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