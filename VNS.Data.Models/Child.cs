using System;
using VNS.Data.Models.Abstracts;
using VNS.Data.Models.Enums;

namespace VNS.Data.Models
{
    public class Child : DataModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        // TODO: check if nullable is ok
        public DateTime? BirthDate { get; set; }

        public GenderType Gender { get; set; }

        public virtual Family Family { get; set; }

        // TODO: check if this relation is ok
        public virtual FamilyMember Father { get; set; }
    }
}
