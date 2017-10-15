using System.Collections.Generic;
using System.Linq;
using VNS.Data.Models.Contracts;
using VNS.Data.Repositories;
using VNS.Services.Contracts;

namespace VNS.Services
{
    public class PageService<T> : IPageService<T>
        where T : class, IDeletable, IAuditable
    {
        private readonly IEfRepository<T> repo;

        public PageService(IEfRepository<T> repo)
        {
            this.repo = repo;
        }

        public int Count
        {
            get
            {
                return this.repo.All.Count();
            }
        }

        public IEnumerable<T> GetPage(short page = 1, short pageSize = 9, string orderBy = "CreatedOn")
        {
            page = page > 0 ? page : (short)1;
            pageSize = pageSize > 0 ? pageSize : (short)9;

            var skipCount = (page - 1) * pageSize;
            var result = this.repo
                .All
                .OrderByDescending(v => v.CreatedOn)
                .Skip(skipCount)
                .Take(pageSize)
                .ToList();

            return result;
        }
    }
}
