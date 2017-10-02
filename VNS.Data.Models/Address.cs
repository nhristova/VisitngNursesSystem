using System.Collections.Generic;
using VNS.Data.Models.Abstracts;

namespace VNS.Data.Models
{
    public class Address : DataModel
    {
        public Address()
        {
            this.People = new List<FamilyMember>();
        }

        public string Location { get; set; }

        public virtual Town Town { get; set; }

        public virtual Municipality Municipality { get; set; }

        public virtual ICollection<FamilyMember> People { get; set; }
    }
}