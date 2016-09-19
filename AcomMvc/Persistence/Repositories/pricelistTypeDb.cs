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
    public class pricelistTypeDb
    {
        private AcomMvcContext db;
        public pricelistTypeDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<pricelistType>> GetAll()
        {
            return null;
        }

        public async Task<pricelistType> GetById(int id)
        {
            return null;
        }

        public async Task<pricelistType> Add(pricelistType pricelistType)
        {
            return null;
        }

        public async Task<pricelistType> Update(pricelistType pricelistType)
        {
            return null;
        }

        public async Task<pricelistType> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}