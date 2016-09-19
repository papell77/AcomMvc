using System.Web.Mvc;

namespace AcomMvc.Areas.Utente
{
    public class UtenteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Utente";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Utente_default",
                "Utente/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}