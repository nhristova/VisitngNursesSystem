using System;
using System.Collections.Generic;
using System.Linq;
using VNS.Data.Models;

namespace VNS.Services.Contracts
{
    public interface IVisitsService
    {
        int Count { get; }

        IQueryable<Visit> GetAll();

        IEnumerable<Visit> GetPage(short page, short size, string orderBy);

        void Update(Visit visit);

        void Add(Visit visit);

        Visit GetById(Guid id);
    }
}