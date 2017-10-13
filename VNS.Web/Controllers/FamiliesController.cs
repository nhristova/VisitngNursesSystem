using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNS.Services.Contracts;

namespace VNS.Web.Controllers
{
    public class FamiliesController : Controller
    {
        private readonly IFamiliesService familiesService;

        public FamiliesController(IFamiliesService familiesService)
        {
            Guard.WhenArgument(familiesService, "familiesService").IsNull().Throw();
            this.familiesService = familiesService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}