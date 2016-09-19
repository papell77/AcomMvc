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
    public class orderRowDb
    {
        private AcomMvcContext db;
        public orderRowDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<orderRow>> GetAll()
        {
            return null;
        }

        public async Task<orderRow> GetById(int id)
        {
            return null;
        }

        public async Task<orderRow> Add(orderRow orderRow)
        {
            return null;
        }

        public async Task<orderRow> Update(orderRow orderRow)
        {
            return null;
        }

        public async Task<orderRow> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}