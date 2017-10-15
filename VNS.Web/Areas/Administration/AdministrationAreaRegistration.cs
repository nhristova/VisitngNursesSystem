using System.Web.Mvc;

namespace VNS.Web.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            // TODO: look for a way to remove area name from the route


            context.MapRoute(
                name: "Administration_default",
                url: "{controller}/{action}/{username}",
                defaults: new { action = "Index", username = "default" },
                constraints: new { controller = "(Admin|Addresses|Users)" }
            );
        }
    }
}