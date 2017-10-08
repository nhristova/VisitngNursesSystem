using System;

namespace VNS.Data.Models.Contracts
{
    public interface IAuditable
    {
        // TODO: check if created on should be nullable
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
