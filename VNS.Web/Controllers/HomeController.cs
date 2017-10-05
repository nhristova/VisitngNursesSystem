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
            ViewBag.Message = "Helping nurses be better at what they do.";

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Documentation page.";

            return View();
        }
    }
}