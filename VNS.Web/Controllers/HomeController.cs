using Bytes2you.Validation;
using System.Web.Mvc;
using VNS.Services.Contracts;

namespace VNS.Web.Controllers
{
    public class HomeController : Controller
    {
        // TODO: Add caching 
        //[OutputCache(CacheProfile = "aa", Duration = 200)]
        private readonly IVisitsService visitsService;

        public HomeController(IVisitsService visitsService)
        {
            Guard.WhenArgument(visitsService, "visitsService").IsNull().Throw();
            this.visitsService = visitsService;
        }

        public ActionResult Index()
        {            

            return View();
        }

        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Helping nurses help families with babies.";

            return View();
        }

        [Route("Help")]
        public ActionResult Help()
        {
            ViewBag.Message = "Documentation page.";

            return View();
        }
    }
}