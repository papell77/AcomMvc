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
    public class familyDb
    {
        private AcomMvcContext db;
        public familyDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<family>> GetAll()
        {
            return null;
        }

        public async Task<family> GetById(int id)
        {
            return null;
        }

        public async Task<family> Add(family family)
        {
            return null;
        }

        public async Task<family> Update(family family)
        {
            return null;
        }

        public async Task<family> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}