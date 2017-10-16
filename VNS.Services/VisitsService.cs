using Bytes2you.Validation;
using System;
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

        public int Count {
            get
            {
                return this.visitRepo.All.Count();
            }
        }

        //public int CountForUser(string username)
        //{
        //    this.visitRepo.All
        //        .Select(v => v.Nurse)
        //}

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
