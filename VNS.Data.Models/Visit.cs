using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VNS.Data.Models.Abstracts;
using VNS.Data.Models.Enums;

namespace VNS.Data.Models
{
    public class Visit : DataModel
    {
        public Visit()
        {
            this.FamilyMembersPresent = new List<FamilyMember>();
        }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public VisitType Type { get; set; }

        public string Description { get; set; }

        public virtual User Nurse { get; set; }

        public virtual Family Family { get; set; }

        // TODO: Check if this works
        public virtual ICollection<FamilyMember> FamilyMembersPresent { get; set; }
    }
}
