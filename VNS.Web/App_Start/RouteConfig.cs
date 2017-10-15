using System.Web.Mvc;
using System.Web.Routing;

namespace VNS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // PascalCase is not for URLs
            routes.LowercaseUrls = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Enable attribute routing
            routes.MapMvcAttributeRoutes();

            // Moved from Global.asax - attempt to fix issue b/n attribute and convention routing
            AreaRegistration.RegisterAllAreas();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}
