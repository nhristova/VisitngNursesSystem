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
            var visits = this.visitsService
                .GetAll()
                .Select(v => new VisitViewModel() {
                    Date = v.Date,
                    NurseName = v.Nurse.UserName,
                    Description = v.Description,
                    CreatedOn = v.CreatedOn.Value,
                    LastModifiedOn = v.ModifiedOn.Value
                })
                .ToList();

            var viewModel = new HomeViewModel()
            {
                Visits = visits
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}