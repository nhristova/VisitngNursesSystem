using System.Linq;
using VNS.DataSystem.Data.Models;
using VNS.DataSystem.Data.Repositories;
using VNS.DataSystem.Services.Contracts;

namespace VNS.DataSystem.Services
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
