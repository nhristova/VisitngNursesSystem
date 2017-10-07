using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using VNS.Data.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace VNS.Data.Models
{
    public class User : IdentityUser, IAuditable, IDeletable
    {
        // TODO: Check why Steven added posts field in demo?
        // Can't we have only a property?
        //private ICollection<Visit> visits;

        public User()
        {
            //this.Families = new List<Family>();
            //// TODO: Check why HasShet?
            //this.visits = new HashSet<Visit>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public virtual ICollection<Family> Families { get; set; }
        //public virtual ICollection<Visit> Visits
        //{
        //    get
        //    {
        //        return this.visits;
        //    }

        //    set
        //    {
        //        this.visits = value;
        //    }
        //}

        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
