using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            this.visitsService = visitsService;
        }

        public ActionResult Index()
        {            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Helping nurses help families with babies.";

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Documentation page.";

            return View();
        }
    }
}