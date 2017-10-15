using System.Collections.Generic;

namespace VNS.Web.Areas.Administration.Models
{
    public class UsersViewModel
    {
        // TODO: should collections in view models be init in ctor??

        public IEnumerable<UserRowViewModel> Users { get; set; }

        public int PageCount { get; set; }
    }
}