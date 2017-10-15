using System.Collections.Generic;
using VNS.Data.Models.Contracts;

namespace VNS.Services.Contracts
{
    public interface IPageService<T> 
        where T : class, IDeletable, IAuditable
    {
        int Count { get; }

        IEnumerable<T> GetPage(short page, short pageSize, string orderBy);
    }
}
