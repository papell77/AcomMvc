using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcomMvc.Core.Domain;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;


namespace AcomMvc.Persistence.Repositories
{
    public class agentDb
    {
        private AcomMvcContext db;
        private string usr;
        public agentDb()
        {
            db = new AcomMvcContext();
            usr = HttpContext.Current.User.Identity.GetUserName();
        }

        public async Task<ICollection<agent>> GetAll()
        {
            try
            {
                List<agent> agents;
                agents = await db.agents.Include(p => p.agentUser).OrderBy(p=>p.agentName).ToListAsync();
                return agents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<agent> GetById(int? id)
        {
            if (id != 0 && id != null)
            {
                try
                {
                    agent agent;
                    agent = await db.agents.Include(p => p.agentUser).FirstOrDefaultAsync(p=>p.ID==id);
                    return agent;
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

        public async Task<agent> Add(agent agent)
        {
            try
            {
                agent.createdBy = usr;
                agent.createdDate = System.DateTime.Today;
                db.agents.Add(agent);
                await db.SaveChangesAsync();
                return agent;
            }
            catch (DbUpdateException e)
            {
                if (db.agents.Where(p => p.agentName == agent.agentName).Count() > 0)
                {
                    var strError="L'agente " + agent.agentName + " esiste già";
                    throw new Exception(strError);                    
                }
                else
                {
                    throw new Exception(e.Message);
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<agent> Update(agent agent)
        {
            agent.updatedBy = usr;
            agent.updatedDate = System.DateTime.Today;
            db.Entry(agent).State = EntityState.Modified;
            try
            {
                //agent updAgent = await db.agents.FindAsync(agent.ID);
               await db.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (db.agents.Where(p => p.agentName == agent.agentName).Count() > 0)
                {
                    var strError = "L'agente " + agent.agentName + " esiste già";
                    throw new Exception(strError);
                }
                else
                {
                    throw new Exception(e.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return agent;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        //Non cancella record, setta a true il campo annull
        //public async Task<agent> Delete(int? id)
        //{
        //    if (id != 0 && id!= null)
        //    {
        //        try
        //        {
        //            agent agent = await db.agents.FindAsync(id);
        //            if (agent != null)
        //            {
        //                agent.updatedBy = usr;
        //                agent.updatedDate = System.DateTime.Today;
        //                agent.annull = true;
        //                await db.SaveChangesAsync();
        //                return agent;
        //            }
        //            else
        //            {
        //                throw new Exception("Agente non trovato");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }
        //    throw new Exception("Formato della richiesta errato");
        //}

    }
}