using System.Web.Mvc;

namespace VNS.Web.Areas.Administration.Controllers
{
    //[RouteArea("Administration")]
    //[Route("{action=index}")]
    public class AdminController : Controller
    {
        //[Route("Administration")]
        public ActionResult Index()
        {
            return View();
        }

        //[Route("Something")]
        public ActionResult Something()
        {
            return View();
        }
    }
}