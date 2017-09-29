using System;

namespace VNS.DataSystem.Data.Model.Contracts
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        // nullabe, set value only when deleted
        DateTime? DeletedOn { get; set; }
    }
}
