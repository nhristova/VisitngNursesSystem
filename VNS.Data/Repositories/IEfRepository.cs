﻿using System;
using System.Linq;
using VNS.Data.Models.Contracts;

namespace VNS.Data.Repositories
{
    public interface IEfRepository<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        T GetById(Guid id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}