using System;
using System.Linq;
using System.Web.Mvc;
using VNS.Data.Models;
using VNS.Services.Contracts;
using VNS.Web.Models.Visits;

namespace VNS.Web.Controllers
{
    public class VisitsController : Controller
    {

        private readonly IMunicipalitiesService municipalitiesService;
        private readonly IVisitsService visitsService;
        private readonly IUsersService usersService;

        public VisitsController(IVisitsService visitsService, IMunicipalitiesService municipalitiesService, IUsersService usersService)
        {
            this.visitsService = visitsService;
            this.municipalitiesService = municipalitiesService;
            this.usersService = usersService;
        }

        public ActionResult Index()
        {
            // TODO: add period filtering
            // TODO: is it better to truncate description here or in view model setter??
            var visits = this.visitsService
                .GetAll()
                .OrderByDescending(v => v.CreatedOn)
                .Select(v => new VisitCardViewModel()
                {
                    Id = v.Id,
                    Date = v.Date,
                    NurseName = v.Nurse.UserName,
                    Description = v.Description
                })
                .ToList();

            var munis = this.municipalitiesService
                .GetAll()
                .Select(m => new MunicipalityViewModel()
                {
                    Name = m.Name,
                    Towns = m.Towns.Select(t => t.Name).ToList()
                })
                .ToList();

            var viewModel = new VisitsViewModel()
            {
                Visits = visits,
                Municipalities = munis
            };

            return View(viewModel);
        }

        public ActionResult Open(Guid id)
        {
            // TODO: Consider another way to stop non-ajax requests
            // without reloading page - AjaxOnly attribute but with some feedback
            // TODO: uncomment when dev finished, add to ather ajax methods
            //if (!this.Request.IsAjaxRequest())
            //{
            //    TempData["message"] = "Not an ajax request";
            //    return RedirectToAction("Index");
            //}

            // TODO: remove
            //var test3 = Request;
            //var test = Request.Url.Query;
            //var test2 = Request.QueryString["name"];

            var v = this.visitsService.GetById(id);
            var vm = new VisitDetailsViewModel()
            {
                Id = v.Id,                
                Date = v.Date,
                NurseName = v.Nurse.UserName,
                Description = v.Description,
                CreatedOn = v.CreatedOn, //.Value,
                LastModifiedOn = v.ModifiedOn//.Value
            };

            return PartialView("_VisitDetailsPartial", vm);
        }

        //[HttpGet]
        [Authorize]
        public ActionResult EditAjax(Guid id)
        {
            var v = this.visitsService.GetById(id);
            var vm = new VisitDetailsViewModel()
            {
                Id = v.Id,
                Date = v.Date,
                NurseName = v.Nurse.UserName,
                Description = v.Description,
                CreatedOn = v.CreatedOn,
                LastModifiedOn = v.ModifiedOn
            };

            return PartialView("_VisitEditPartial", vm);
        }

        // TODO: Add to all post actions
        //[ValidateAntiForgeryToken]
        //[Authorize]
        [HttpPost]
        public ActionResult EditAjax(VisitDetailsViewModel visit)
        {
            // if view model not valid
            if (!ModelState.IsValid)
            {
                return PartialView("_VisitEditPartial", visit);
            }

            // find the visit to edit from database
            var v = this.visitsService.GetById(visit.Id);

            // update
            v.Date = visit.Date;
            v.Description = visit.Description;
            this.visitsService.Update(v);

            // cheat
            visit.LastModifiedOn = DateTime.Now;

            return PartialView("_VisitDetailsPartial", visit);
        }


        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(VisitDetailsViewModel visit)
        {
            if (!ModelState.IsValid)
            {
                return View(visit);
            }

            var v = new Visit()
            {
                Date = visit.Date,
                Description = visit.Description,
                // TODO: check if works search based on username
                Nurse = this.usersService.GetByName(visit.NurseName)
            };

            this.visitsService.Add(v);

            // TODO: review - add success message, redirect??
            TempData["message"] = "Visit added successfully";
            return Redirect("Index");
        }
    }
}