using System.Collections.Generic;
using VNS.Data.Models.Abstracts;

namespace VNS.Data.Models
{
    public class Family : DataModel
    {
        public Family()
        {
            this.Members = new List<FamilyMember>();
            this.Chilren = new List<Child>();
        }

        public string LastName { get; set; }

        public virtual string UserName { get; set; }

        public virtual ICollection<FamilyMember> Members { get; set; }

        public virtual ICollection<Child> Chilren { get; set; }
    }
}