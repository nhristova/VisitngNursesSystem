using System;

namespace VNS.DataSystem.Data.Model.Contracts
{
    interface IAuditable
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
