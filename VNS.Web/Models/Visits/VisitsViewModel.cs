using System.Collections.Generic;

namespace VNS.Web.Models.Visits
{
    public class VisitsViewModel
    {
        // TODO: should collections in view models be init in ctor??

        public IEnumerable<VisitCardViewModel> Visits { get; set; }

        public int PageCount { get; set; }
    }
}