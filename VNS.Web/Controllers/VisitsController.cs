﻿using System;
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

        public VisitsController(IVisitsService visitsService, IMunicipalitiesService municipalitiesService)
        {
            this.visitsService = visitsService;
            this.municipalitiesService = municipalitiesService;
        }

        public ActionResult Index()
        {
            // TODO: add period filtering
            // TODO: is it better to truncate description here or in view model setter??
            var visits = this.visitsService
                .GetAll()
                .Select(v => new VisitCardViewModel()
                {
                    Date = v.Date,
                    NurseName = v.Nurse.UserName,
                    Description = v.Description,
                    CreatedOn = v.CreatedOn.Value,
                    LastModifiedOn = v.ModifiedOn.Value
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

        public ActionResult Open(string id)
        {
            var test3 = Request;
            var test = Request.Url.Query;
            var test2 = Request.QueryString["name"];

            var v = this.visitsService.GetAll().First();
            var vm = new VisitDetailsViewModel()
            {
                Date = v.Date,
                NurseName = v.Nurse.UserName,
                Description = v.Description,
                CreatedOn = v.CreatedOn.Value,
                LastModifiedOn = v.ModifiedOn.Value
            };

            return PartialView("_VisitDetailsPartial", vm);
        }

        //[HttpGet]
        public ActionResult Edit(int? id)
        {
            var test = Request.Url.Query;
            var test2 = Request.QueryString["name"];

            var v = this.visitsService.GetAll().First();
            var vm = new VisitDetailsViewModel()
            {
                Date = v.Date,
                NurseName = v.Nurse.UserName,
                Description = v.Description,
                CreatedOn = v.CreatedOn.Value,
                LastModifiedOn = v.ModifiedOn.Value
            };

            return PartialView("_VisitEditPartial", vm);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(VisitDetailsViewModel visit)
        {
            //this.Request.IsAjaxRequest();
            var test = Request.Url.Query;
            var test2 = Request.QueryString["name"];

            var v = this.visitsService.GetAll().First();
            var vm = new VisitDetailsViewModel()
            {
                Date = v.Date,
                NurseName = v.Nurse.UserName,
                Description = v.Description,
                CreatedOn = v.CreatedOn.Value,
                LastModifiedOn = v.ModifiedOn.Value
            };

            return PartialView("_VisitEditPartial", vm);
        }


        public ActionResult Form()
        {
            var v = this.visitsService.GetAll().First();
            var vm = new VisitDetailsViewModel()
            {
                Date = v.Date,
                NurseName = v.Nurse.UserName,
                Description = v.Description,
                CreatedOn = v.CreatedOn.Value,
                LastModifiedOn = v.ModifiedOn.Value
            };

            return View(vm);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Form(VisitDetailsViewModel visit)
        {
            // if view model not valid
            if (!ModelState.IsValid)
            {
                return View(visit);
            }

            // TODO: find the correct visit to edit
            var v = this.visitsService.GetAll().First();

            // update in database
            v.Date = visit.Date;
            v.Description = visit.Description;
            this.visitsService.Update(v);

            return View(visit);
        }
    }
}