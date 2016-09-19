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
    public class paymentDb
    {
        private AcomMvcContext db;
        public paymentDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<payment>> GetAll()
        {
            return null;
        }

        public async Task<payment> GetById(int id)
        {
            return null;
        }

        public async Task<payment> Add(payment payment)
        {
            return null;
        }

        public async Task<payment> Update(payment payment)
        {
            return null;
        }

        public async Task<payment> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}