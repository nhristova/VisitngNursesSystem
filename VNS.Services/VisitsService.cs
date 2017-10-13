using Bytes2you.Validation;
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
            Guard.WhenArgument(visitRepo, "visitRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
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

        public IEnumerable<Visit> GetPage(short page = 1, short pageSize = 9, string orderBy = "CreatedOn")
        {
            // TODO: add different order types with if statements??
            // TODO: does returning a list slow app, if I call ToList() in service too ??
            // TODO: add checks for zero and negative values
            page = page > 0 ? page : (short)1;
            pageSize = pageSize > 0 ? pageSize : (short)9;

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
            // TODO need this?
            Guard.WhenArgument(visit, "visit").IsNull().Throw();

            this.visitRepo.Update(visit);
            this.context.Commit();
        }

        public void Add(Visit visit)
        {
            // TODO need this?
            Guard.WhenArgument(visit, "visit").IsNull().Throw();

            this.visitRepo.Add(visit);
            this.context.Commit();
        }

        public Visit GetById(Guid? id)
        {
            Visit result = null;

            if (id.HasValue)
            {
                result = this.visitRepo
                    .GetById(id.Value);
            }
            return result;
        }
    }
}
