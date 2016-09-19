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
    public class countyDb
    {
        private AcomMvcContext db;
        private string usr;
        public countyDb()
        {
            db = new AcomMvcContext();
            usr = HttpContext.Current.User.Identity.GetUserName();
        }

        public ICollection<county> GetAll()
        {
            try
            {
                List<county> counties= db.counties.ToList();
                return counties;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<county>> GetAllNotNull()
        {
            try
            {
                List<county> counties = await db.counties.Where(p=>p.annull==false).ToListAsync();
                return counties;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<county> GetById(int? id)
        {
            if (id != 0 && id != null)
            {
                try
                {
                    county county = await db.counties.FindAsync(id);
                    return county;
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

        public async Task<county> Add(county county)
        {
            try
            {
                county.createdBy = usr;
                county.createdDate = System.DateTime.Today;
                db.counties.Add(county);
                await db.SaveChangesAsync();
                return county;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<county> Update(county county)
        {
            try
            {
                county.updatedBy = usr;
                county.updatedDate = System.DateTime.Today;
                db.Entry<county>(county).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return county;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<county> Delete(int? id)
        {
            if (id != 0 && id != null)
            {
                try
                {
                    county county = await db.counties.FindAsync(id);
                    if(county!=null)
                    {
                        county.updatedBy = usr;
                        county.updatedDate = System.DateTime.Today;
                        county.annull = true;
                        db.Entry<county>(county).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                        return county; 
                    }
                    else
                    {
                        throw new Exception("Provincia non trovata");
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