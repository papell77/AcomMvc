using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AcomMvc.Core.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AcomMvc.Persistence
{
    public class AcomMvcContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<agent> agents { get; set; }
        public DbSet<canal> canals { get; set; }
        public DbSet<city> cities { get; set; }
        public DbSet<client> clients { get; set; }
        public DbSet<clientContact> clientContacts { get; set; }
        public DbSet<clientOffice> clientOffices { get; set; }
        public DbSet<county> counties { get; set; }
        public DbSet<delivery> deliveries { get; set; }
        public DbSet<family> families { get; set; }
        public DbSet<offer> offers { get; set; }
        public DbSet<offerRow> offerRows { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<orderRow> orderRows { get; set; }
        public DbSet<payment> payments { get; set; }
        public DbSet<pricelist> pricelists { get; set; }
        public DbSet<pricelistType> pricelistTypes { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<shipment> shipments { get; set; }
        public DbSet<visit> visits { get; set; }
        public DbSet<warranty> warranties { get; set; }

        public AcomMvcContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public static AcomMvcContext Create()
        {
            return new AcomMvcContext();
        }

        //public System.Data.Entity.DbSet<AcomMvc.Core.Domain.ApplicationUser> ApplicationUsers { get; set; }
    }
}