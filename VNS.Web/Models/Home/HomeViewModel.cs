using System.Collections.Generic;

namespace VNS.Web.Models.Home
{
    public class HomeViewModel
    {

        public ICollection<VisitViewModel> Visits { get; set; }

        public ICollection<VisitViewModel> Families { get; set; }

        public ICollection<VisitViewModel> Children { get; set; }

        public ICollection<VisitViewModel> Pregnant { get; set; }



    }
}