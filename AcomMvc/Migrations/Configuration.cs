namespace AcomMvc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using AcomMvc.Core.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<AcomMvc.Persistence.AcomMvcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AcomMvc.Persistence.AcomMvcContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var rolemng = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string RuoloAdmin = "Admin";
            var roleAdmin = rolemng.FindByName(RuoloAdmin);
            if (roleAdmin == null)
            {
                roleAdmin=new IdentityRole{Name=RuoloAdmin};
                IdentityResult idAdminRoleResult;
                try
                {
                    idAdminRoleResult = rolemng.Create(roleAdmin);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                if (!idAdminRoleResult.Succeeded)
                {
                    Console.Write(idAdminRoleResult.Errors);
                }
            }

            string RuoloUtente = "Utente";
            var roleUte = rolemng.FindByName(RuoloUtente);
            if (roleUte == null)
            {
                roleUte = new IdentityRole { Name = RuoloUtente };
                IdentityResult idUteRoleResult;
                try
                {
                    idUteRoleResult = rolemng.Create(roleUte);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                if (!idUteRoleResult.Succeeded)
                {
                    Console.Write(idUteRoleResult.Errors);
                }
            }

            string RuoloDE = "Data Entry";
            var roleDE = rolemng.FindByName(RuoloDE);
            if (roleDE == null)
            {
                roleDE = new IdentityRole { Name = RuoloDE };
                IdentityResult idDERoleResult;
                try
                {
                    idDERoleResult = rolemng.Create(roleDE);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                if (!idDERoleResult.Succeeded)
                {
                    Console.Write(idDERoleResult.Errors);
                }
            }

            var usrmng = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string amminist = "admin@gmail.com";
            string pwdAdmin = "adminadmin";
            IdentityResult idUserResult_admin;
            var appAdmin=usrmng.FindByEmail(amminist);

            if(appAdmin== null)
            {
                appAdmin=new ApplicationUser {UserName=amminist, Email=amminist};
                try 
	            {	        
		            idUserResult_admin=usrmng.Create(appAdmin, pwdAdmin);
	            }
	            catch (Exception ex)
	            {
		            throw new Exception(ex.Message);
	            }

                if(idUserResult_admin.Succeeded)
                {
                    if(!usrmng.IsInRole(appAdmin.Id, RuoloAdmin))
                    {
                        idUserResult_admin=usrmng.AddToRole(appAdmin.Id, RuoloAdmin);
                    }
                    else
                    {
                        Console.Write(idUserResult_admin.Errors);
                    }
                }
            }
        }
    }
}
