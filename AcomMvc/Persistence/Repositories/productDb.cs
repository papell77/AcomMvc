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
    public class productDb
    {
        private AcomMvcContext db;
        public productDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<product>> GetAll()
        {
            return null;
        }

        public async Task<product> GetById(int id)
        {
            return null;
        }

        public async Task<product> Add(product product)
        {
            return null;
        }

        public async Task<product> Update(product product)
        {
            return null;
        }

        public async Task<product> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}