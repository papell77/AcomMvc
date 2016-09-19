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
    public class offerRowDb
    {
        private AcomMvcContext db;
        public offerRowDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<offerRow>> GetAll()
        {
            return null;
        }

        public async Task<offerRow> GetById(int id)
        {
            return null;
        }

        public async Task<offerRow> Add(offerRow offerRow)
        {
            return null;
        }

        public async Task<offerRow> Update(offerRow offerRow)
        {
            return null;
        }

        public async Task<offerRow> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}