using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VNS.Data.Models;

namespace VNS.Web.Areas.Administration.Models
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel()
        {

        }

        public UserDetailsViewModel(User user)
        {
            this.Id = user.Id;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.IsDeleted = user.IsDeleted;
            this.Email = user.Email;
            this.UserName = user.UserName;
            this.UserRoles = user.Roles.Select(r => r.RoleId).ToList();
            this.PhoneNumber = user.PhoneNumber;
            this.UserRoles = new List<string>();
            // TODO: implement
            this.FamiliesCount = 0;
            this.VisitsCount = 0;
        }

        // TODO add validation
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Status")]
        public bool IsDeleted { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public IEnumerable<string> UserRoles { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public int FamiliesCount { get; set; }

        public int VisitsCount { get; set; }
    }
}