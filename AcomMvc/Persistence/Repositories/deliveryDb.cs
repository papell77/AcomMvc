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
    public class deliveryDb
    {
        private AcomMvcContext db;
        public deliveryDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<delivery>> GetAll()
        {
            return null;
        }

        public async Task<delivery> GetById(int id)
        {
            return null;
        }

        public async Task<delivery> Add(delivery delivery)
        {
            return null;
        }

        public async Task<delivery> Update(delivery delivery)
        {
            return null;
        }

        public async Task<delivery> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}