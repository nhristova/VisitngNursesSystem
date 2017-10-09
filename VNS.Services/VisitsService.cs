using System;
using System.Collections.Generic;
using System.Linq;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Data.SaveContext;
using VNS.Services.Contracts;

namespace VNS.Services
{
    public class VisitsService : IVisitsService
    {
        private readonly IEfRepository<Visit> visitRepo;
        private readonly ISaveContext context;

        public VisitsService(IEfRepository<Visit> visitRepo, ISaveContext context)
        {
            this.visitRepo = visitRepo;
            this.context = context;
        }

        public int Count
        {
            get
            {
                return this.visitRepo.All.Count();
            }
        }

        // TODO: Think how to return something other than IQueryable
        public IQueryable<Visit> GetAll()
        {
            return this.visitRepo.All;
        }

        public IEnumerable<Visit> GetPage(short page, short pageSize, string orderBy)
        {
            // TODO: add different order types with if statements??
            // TODO: does returning a list slow app, if I call ToList() in service too ??
            var skipCount = (page - 1) * pageSize;
            var result = this.visitRepo
                .All
                .OrderByDescending(v => v.CreatedOn)
                .Skip(skipCount)
                .Take(pageSize)
                .ToList();

            return result;
        }

        public void Update(Visit visit)
        {
            this.visitRepo.Update(visit);
            this.context.Commit();
        }

        public void Add(Visit visit)
        {
            this.visitRepo.Add(visit);
            this.context.Commit();
        }

        public Visit GetById(Guid id)
        {
            var result = this.visitRepo
                .All
                .SingleOrDefault(v => v.Id == id);

            return result;
        }
    }
}
