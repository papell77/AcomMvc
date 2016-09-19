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
    public class visitDb
    {
        private AcomMvcContext db;
        public visitDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<visit>> GetAll()
        {
            return null;
        }

        public async Task<visit> GetById(int id)
        {
            return null;
        }

        public async Task<visit> Add(visit visit)
        {
            return null;
        }

        public async Task<visit> Update(visit visit)
        {
            return null;
        }

        public async Task<visit> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}