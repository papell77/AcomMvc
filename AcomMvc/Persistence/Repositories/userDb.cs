using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcomMvc.Core.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AcomMvc.Persistence.Repositories
{
    public class userDb
    {
        private AcomMvcContext db;
        public userDb()
        {
            db = new AcomMvcContext();
        }

        public async Task<ICollection<ApplicationUser>> GetAll()
        {
            try
            {
                List<ApplicationUser> users;
                users = await db.Users.Include(p=>p.Roles).ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<ApplicationUser>> GetAllUnlocked()
        {
            try
            {
                List<ApplicationUser> users;
                users = await db.Users.Include(p => p.Roles).Where(p=>p.LockoutEnabled==false).ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApplicationUser> LockOut(ApplicationUser ApplicationUser)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var result = await manager.SetLockoutEnabledAsync(ApplicationUser.Id, true);
            if (result.Succeeded)
            {
                DateTimeOffset dateOff=new DateTimeOffset(new DateTime(2100,1,1));
                result= await manager.SetLockoutEndDateAsync(ApplicationUser.Id, dateOff);
                if (result.Succeeded)
                {
                    return ApplicationUser;
                }
                else
                {
                    throw new Exception("Blocco utente non riuscito, data di sblocco non valida: " + result.Errors);
                }
            }
            else
            {
                throw new Exception("Blocco utente non riuscito " + result.Errors);
            }
        }

        public async Task<ApplicationUser> Unlock(ApplicationUser ApplicationUser)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var result = await manager.SetLockoutEnabledAsync(ApplicationUser.Id, false);
            if (result.Succeeded)
            {
                return ApplicationUser;
            }
            else
            {
                throw new Exception("Sblocco utente non riuscito " + result.Errors);
            }
        }

        public async Task<ApplicationUser> ResetPassword(string userId)
        {
            string newPwd = "A123b456c789D";

            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user;
            try 
	        {	        
		        user = await manager.FindByIdAsync(userId);
	        }
	        catch (Exception ex)
	        {
		        throw new Exception(ex.Message);
	        }            
            
            //genero l'hash della nuova password
            try 
            {	        
                 user.PasswordHash = manager.PasswordHasher.HashPassword(newPwd);
	        }
	        catch (Exception ex)
	        {
		        throw new Exception(ex.Message);
	        }            
            
            //aggiorno il security stamp
            try 
	        {	        
		        await manager.UpdateSecurityStampAsync(userId);
	        }
	        catch (Exception ex)
	        {
		        throw new Exception(ex.Message);
	        }

            //salvo la nuova password
            var result = await manager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                throw new Exception("Reset password non riuscito");
            }
        }

        //public async Task<ApplicationUser> Add(ApplicationUser ApplicationUser)
        //{
        //    return null;
        //}

        //public async Task<ApplicationUser> Update(ApplicationUser ApplicationUser)
        //{
        //    return null;
        //}

        //public async Task<ApplicationUser> Delete(int? id)
        //{
        //    return null;
        //}

        public void Dispose()
        {
            db.Dispose();
        }


    }
}