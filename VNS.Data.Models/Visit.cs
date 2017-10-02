using System;
using System.ComponentModel.DataAnnotations;
using VNS.Data.Models.Abstracts;

namespace VNS.Data.Models
{
    public class Visit : DataModel
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual User Nurse { get; set; }

        public string Description { get; set; }
    }
}
