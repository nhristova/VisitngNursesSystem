using VNS.Data.Models.Abstracts;
using VNS.Data.Models.Enums;

namespace VNS.Data.Models
{
    public class FamilyMember : DataModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Family Family { get; set; }

        // TODO: allow only one mother per family
        public RoleType Role { get; set; }

        public GenderType Gender { get; set; }

        public virtual Address Address { get; set; }

    }
}
