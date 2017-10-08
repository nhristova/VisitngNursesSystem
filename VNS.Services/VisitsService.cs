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

        public IQueryable<Visit> GetAll()
        {
            return this.visitRepo.All;
        }
        
        public void Update(Visit visit)
        {
            this.visitRepo.Update(visit);
            this.context.Commit();
        }        
    }
}
