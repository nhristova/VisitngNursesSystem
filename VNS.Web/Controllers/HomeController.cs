using Bytes2you.Validation;
using System.Web.Mvc;
using VNS.Services.Contracts;
using VNS.Web.Models.Home;

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
            var vm = new HomeViewModel()
            {
                VisitsTotal = this.visitsService.Count,

            };
            return View(vm);
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