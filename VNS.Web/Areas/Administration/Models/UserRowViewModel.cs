using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VNS.Data.Models;

namespace VNS.Web.Areas.Administration.Models
{
    public class UserRowViewModel
    {

        public UserRowViewModel()
        {

        }

        public UserRowViewModel(User user)
        {
            this.Id = user.Id;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.IsDeleted = user.IsDeleted;
            this.Email = user.Email;
            this.UserName = user.UserName;
            this.UserRoles = user.Roles.Select(r => r.RoleId).ToList();
            // TODO: implement
            this.FamiliesCount = 0;
            this.VisitsCount = 0;
        }

        // TODO add validation
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [Display(Name = "Deactivate")]
        public bool IsDeleted { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public ICollection<string> UserRoles { get; set; }

        public int FamiliesCount { get; set; }

        public int VisitsCount { get; set; }

    }
}