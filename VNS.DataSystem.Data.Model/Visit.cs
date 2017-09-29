using System;
using System.ComponentModel.DataAnnotations;

namespace VNS.DataSystem.Data.Model
{
    public class Visit
    {
        public Visit()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
