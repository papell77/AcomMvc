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
    public class pricelistDb
    {
        private AcomMvcContext db;
        public pricelistDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<pricelist>> GetAll()
        {
            return null;
        }

        public async Task<pricelist> GetById(int id)
        {
            return null;
        }

        public async Task<pricelist> Add(pricelist pricelist)
        {
            return null;
        }

        public async Task<pricelist> Update(pricelist pricelist)
        {
            return null;
        }

        public async Task<pricelist> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}