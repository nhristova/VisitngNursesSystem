using System.Linq;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Services.Contracts;

namespace VNS.Services
{
    public class VisitsService : IVisitsService
    {
        private readonly IEfRepository<Visit> visitRepo;

        public VisitsService(IEfRepository<Visit> visitRepo)
        {
            this.visitRepo = visitRepo;
        }

        public IQueryable<Visit> GetAll()
        {
            return this.visitRepo.All;
        }        
    }
}
