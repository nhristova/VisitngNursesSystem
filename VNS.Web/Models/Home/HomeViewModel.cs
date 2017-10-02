using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VNS.Web.Models.Home
{
    public class HomeViewModel
    {
        public ICollection<VisitViewModel> Visits { get; set; }
    }
}