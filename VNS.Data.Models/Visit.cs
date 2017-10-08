using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VNS.Data.Models.Abstracts;
using VNS.Data.Models.Enums;
using VNS.Data.Models.ValidationRules;
using Rules = VNS.Data.Models.ValidationRules.PropertiesConstraints;

namespace VNS.Data.Models
{
    public class Visit : DataModel
    {
        public Visit()
        {
            this.FamilyMembersPresent = new List<FamilyMember>();
        }

        [DataType(DataType.Date)]
        [PastDate]
        public DateTime Date { get; set; }
        
        public VisitType Type { get; set; }

        //[StringLength(Rules.DescriptionMaxLength, ErrorMessage = Rules.StringLengthError, MinimumLength = Rules.DescriptionMinLength)]
        public string Description { get; set; }

        public virtual User Nurse { get; set; }

        public virtual Family Family { get; set; }

        // TODO: Check if this works
        public virtual ICollection<FamilyMember> FamilyMembersPresent { get; set; }
    }
}
