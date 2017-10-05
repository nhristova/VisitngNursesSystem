using System.Linq;
using System.Web.Mvc;
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
            var visits = this.visitsService
                .GetAll()
                .Select(v => new VisitDetailsViewModel()
                {
                    Date = v.Date,
                    NurseName = v.VisitingNurse.UserName,
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
    }
}