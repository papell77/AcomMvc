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
    public class orderDb
    {
        private AcomMvcContext db;
        public orderDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<order>> GetAll()
        {
            return null;
        }

        public async Task<order> GetById(int id)
        {
            return null;
        }

        public async Task<order> Add(order order)
        {
            return null;
        }

        public async Task<order> Update(order order)
        {
            return null;
        }

        public async Task<order> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}