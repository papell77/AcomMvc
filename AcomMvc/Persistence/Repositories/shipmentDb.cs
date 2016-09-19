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
    public class shipmentDb
    {
        private AcomMvcContext db;
        public shipmentDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<shipment>> GetAll()
        {
            return null;
        }

        public async Task<shipment> GetById(int id)
        {
            return null;
        }

        public async Task<shipment> Add(shipment shipment)
        {
            return null;
        }

        public async Task<shipment> Update(shipment shipment)
        {
            return null;
        }

        public async Task<shipment> Delete(int? id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }


    }
}