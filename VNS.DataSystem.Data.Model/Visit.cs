using System;
using System.ComponentModel.DataAnnotations;
using VNS.DataSystem.Data.Models.Abstracts;

namespace VNS.DataSystem.Data.Models
{
    // TODO: Check if should inherit DataModel
    public class Visit : DataModel
    {
        // TODO: Check, if not inheriting data model, should have id?
        //public Visit()
        //{
        //    this.Id = Guid.NewGuid();
        //}

        //[Key]
        //public Guid Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
