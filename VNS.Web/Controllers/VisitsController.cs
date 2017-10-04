using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VNS.Web.Controllers
{
    public class VisitsController : Controller
    {
        public VisitsController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}