using System.Collections.Generic;

namespace VNS.Web.Models.Visits
{
    public class VisitsViewModel
    {
        public ICollection<MunicipalityViewModel> Municipalities { get; set; }
        public ICollection<VisitDetailsViewModel> Visits { get; set; }
    }
}