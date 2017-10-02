using System.Web.Mvc;

namespace VNS.Web.Helpers
{
    public static class Helpers
    {
        public static string IsActive(this HtmlHelper html, string control, string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = routeData.Values["action"].ToString();
            var routeControl = routeData.Values["controller"].ToString();

            if (control == routeControl && action == routeAction)
            {
                return "active";
            }

            return "";
        }

    }
}