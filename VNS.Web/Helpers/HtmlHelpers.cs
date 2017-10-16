using System;
using System.Web.Mvc;

namespace VNS.Web.Helpers
{
    public static class HtmlHelpers
    {
        public static string IsActive(this HtmlHelper html, string control, string action)
        {
            var routeData = html.ViewContext.RouteData;
            
            var routeAction = routeData.Values["action"].ToString();
            var routeControl = routeData.Values["controller"].ToString();

            // In case of Home, want to check the action too
            if (control == "Home" || control == "Account")
            {
                if (control.ToLower() == routeControl.ToLower() && action.ToLower() == routeAction.ToLower())
                {
                    return "active";
                }
            }
            // In case of other controllers, only want to check the controller
            else 
            {
                if (control.ToLower() == routeControl.ToLower())
                {
                    return "active";
                }
            }

            return "";
        }

       // public static MvcHtmlString Status(this HtmlHelper html, bool isDeleted)
       // {

       //     if(!isDeleted)
       //{
       //         Html.Label("Inactive", new { @class = "label label-default" })
       //}
       //else
       //{
       //         @Html.Label("Active", new { @class = "label label-success" })
       //}


       //     return MvcHtmlString.Create
       // }

        /// <summary>
        /// Creates a li element with anchor tag, fa icon and text.  
        /// Checks if the current url mathes the a tag and sets li class to active.
        /// Adds tooltip too.
        /// </summary>
        /// <param name="html">Html context to extract the current url from</param>
        /// <param name="controller">Target controller</param>
        /// <param name="action">Target action</param>
        /// <returns>MvcHtmlString tag</returns>
        //public static MvcHtmlString LinkIsActiveLi(this HtmlHelper html, string controller, string action, string faIconName)
        //{
        //    var routeData = html.ViewContext.RouteData;

        //    var routeAction = routeData.Values["action"].ToString();
        //    var routeControl = routeData.Values["controller"].ToString();

        //    var isActive = "";

        //    if (controller.ToLower() == routeControl.ToLower() && action.ToLower() == routeAction.ToLower())
        //    {
        //        isActive = "active";
        //    }

        //    var iTag = new TagBuilder("i");
        //    iTag.AddCssClass(faIconName + " fa fa-2x fa-fw hidden-md hidden-lg");
        //    iTag.MergeAttribute("title", controller);
        //    iTag.MergeAttribute("data-toggle", "tooltip");
        //    iTag.MergeAttribute("data-placement", "bottom");

        //    var spanTag = new TagBuilder("span");
        //    spanTag.AddCssClass("hidden-sm");
        //    spanTag.InnerHtml = "&nbsp; " + controller;

        //    var aTag = new TagBuilder("a");
        //    aTag.MergeAttribute("href", controller.ToLower());
        //    aTag.InnerHtml = iTag.ToString(TagRenderMode.Normal) + spanTag.ToString(TagRenderMode.Normal);

        //    var liTag = new TagBuilder("li");
        //    liTag.AddCssClass(isActive);
        //    liTag.InnerHtml = aTag.ToString(TagRenderMode.Normal);           

        //    return MvcHtmlString.Create(liTag.ToString(TagRenderMode.Normal));
        //}
    }

    // TODO: remove if not used
    //[AttributeUsage(AttributeTargets.Method)]
    //public class AjaxOnlyAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        if (!filterContext.HttpContext.Request.IsAjaxRequest())
    //        {
    //            filterContext.HttpContext.Response.Write("NOT AJAX");
    //            //filterContext.Result = new HttpNotFoundResult();
    //        }
    //        else
    //        {
    //            base.OnActionExecuting(filterContext);
    //        }
    //    }
    //}
}