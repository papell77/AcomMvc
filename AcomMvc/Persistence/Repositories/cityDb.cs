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
    public class cityDb
    {
        private AcomMvcContext db;
        private string usr;
        public cityDb()
        {
            db = new AcomMvcContext();
            usr = HttpContext.Current.User.Identity.GetUserName();
        }

        public async Task<ICollection<city>> GetAll()
        {
            try
            {
                List<city> cities = await db.cities.OrderBy(p=>p.cityName).ToListAsync();
                return cities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<city> GetById(int? id)
        {
            if (id != 0 && id != null)
            {
                city city;
                try
                {
                    city = await db.cities.OrderBy(p=>p.cityName).FirstOrDefaultAsync(p=>p.ID==id);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return city;
            }
            else
            {
                throw new Exception("Formato della richiesta errato");
            }
        }

        public async Task<ICollection<city>> GetByCountyId(int? id)
        {
            List<city> cities;
            if (id != 0 && id != null)
            {
                try
                {
                    cities = await db.cities.Where(p => p.countyID == id).OrderBy(p=>p.cityName).ToListAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return cities;
            }
            else //in mancanza di un riferimento all'id provincia restituisco null
            {
                try
                {
                    cities = await db.cities.OrderBy(p => p.cityName).ToListAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return cities;
            }

        }

        public async Task<city> Add(city city)
        {
            try
            {
                city.createdBy = usr;
                city.createdDate = System.DateTime.Today;
                db.cities.Add(city);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return city;
        }

        public async Task<city> Update(city city)
        {
            try
            {
                city.updatedBy = usr;
                city.updatedDate = System.DateTime.Today;
                db.Entry<city>(city).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return city;
        }

        public async Task<city> Delete(int? id)
        {
            if (id != 0 && id != null)
            {
                city city;
                try
                {
                    city = await db.cities.FindAsync(id);
                    if (city != null)
                    {
                        city.updatedBy = usr;
                        city.updatedDate = System.DateTime.Today;
                        city.annull = true;
                        await db.SaveChangesAsync();
                        return city;
                    }
                    else
                    {
                        throw new Exception("Città non trovata");
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