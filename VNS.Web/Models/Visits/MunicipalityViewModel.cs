using System.Collections.Generic;

namespace VNS.Web.Models.Visits
{
    public class MunicipalityViewModel
    {
        public string Name { get; set; }

        public ICollection<string> Towns { get; set; }
    }
}