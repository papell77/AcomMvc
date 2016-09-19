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
    public class offerDb
    {
        private AcomMvcContext db;
        public offerDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<offer>> GetAll()
        {
            return null;
        }

        public async Task<offer> GetById(int id)
        {
            return null;
        }

        public async Task<offer> Add(offer offer)
        {
            return null;
        }

        public async Task<offer> Update(offer offer)
        {
            return null;
        }

        public async Task<offer> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}