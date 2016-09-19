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
    public class warrantyDb
    {
        private AcomMvcContext db;
        public warrantyDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<warranty>> GetAll()
        {
            return null;
        }

        public async Task<warranty> GetById(int id)
        {
            return null;
        }

        public async Task<warranty> Add(warranty warranty)
        {
            return null;
        }

        public async Task<warranty> Update(warranty warranty)
        {
            return null;
        }

        public async Task<warranty> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}