using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VNS.DataSystem.Data.Models.Contracts;

namespace VNS.DataSystem.Data.Models.Abstracts
{
    // TODO: Add record of user who modified data??
    public abstract class DataModel : IAuditable, IDeletable
    {
        public DataModel()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        // TODO: Should this be nullabe?
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
    }
}
