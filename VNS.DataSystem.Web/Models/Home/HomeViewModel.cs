using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VNS.DataSystem.Web.Models.Home
{
    public class HomeViewModel
    {
        public ICollection<VisitViewModel> Visits { get; set; }
    }
}