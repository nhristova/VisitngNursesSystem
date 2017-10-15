using Bytes2you.Validation;
using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;
using VNS.Auth.Contracts;
using VNS.Data.Models;
using VNS.Services.Contracts;
using VNS.Web.Models.Visits;
using static VNS.Web.Helpers.HtmlHelpers;

namespace VNS.Web.Controllers
{
    public class VisitsController : Controller
    {

        private readonly IMunicipalitiesService municipalitiesService;
        private readonly IVisitsService visitsService;
        private readonly IUserService usersService;
        private readonly IPageService<Visit> pageService;

        public VisitsController(IVisitsService visitsService, IMunicipalitiesService municipalitiesService, IUserService usersService, IPageService<Visit> pageService)
        {
            Guard.WhenArgument(visitsService, "visitsService").IsNull().Throw();
            Guard.WhenArgument(municipalitiesService, "municipalitiesService").IsNull().Throw();
            Guard.WhenArgument(usersService, "usersService").IsNull().Throw();
            this.visitsService = visitsService;
            this.municipalitiesService = municipalitiesService;
            this.usersService = usersService;
            this.pageService = pageService;
        }

        public ActionResult Index(short page = 1, short pageSize = 9, string orderBy = "CreatedOn")
        {
            // TODO: add period filtering
            var munis = this.municipalitiesService
                .GetAll()
                .Select(m => new MunicipalityViewModel()
                {
                    Name = m.Name,
                    Towns = m.Towns.Select(t => t.Name).ToList()
                })
                .ToList();

            var viewModel = new SearchViewModel()
            {
                Municipalities = munis,             
            };

            return View(viewModel);
        }

		// TODO : consider adding ajaxOnly check
        //[AjaxOnly]
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

            var visit = this.visitsService.GetById(id);

            VisitDetailsViewModel vm = new VisitDetailsViewModel(visit);

            return PartialView("_VisitDetailsPartial", vm);
        }

        // TODO: Fix redirect not working for not logged user
        //[HttpGet]
        [Authorize]
        public ActionResult Edit(Guid id)
        {
            // TODO: Check for null
            var visit = this.visitsService.GetById(id);
            var vm = new VisitDetailsViewModel(visit);

            return PartialView("_VisitEditPartial", vm);
        }

        // TODO: Add to all post actions
        //[ValidateAntiForgeryToken]
        //[Authorize]
        [HttpPost]
        public ActionResult Edit(VisitDetailsViewModel visit)
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
                Nurse = this.usersService.GetByUserName(visit.NurseName)
            };

            this.visitsService.Add(v);

            // TODO: review - add success message, redirect??
            TempData["message"] = "Visit added successfully";
            return Redirect("Index");
        }

        public ActionResult List(short page = 1, short pageSize = 6, string orderBy = "CreatedOn")
        {
            var pagedVisits = this.pageService
                .GetPage(page, pageSize, orderBy)
                .Select(v => new VisitCardViewModel(v));

            var pages = this.visitsService.Count / pageSize;
            pages = this.visitsService.Count % pageSize == 0 ? pages : ++pages;
            
            var vm = new VisitsViewModel()
            {
                Visits = pagedVisits,
                PageCount = pages
            };

            return PartialView("_VisitsListPartial", vm);
        }
    }
}