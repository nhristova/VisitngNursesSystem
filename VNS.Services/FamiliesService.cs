using Bytes2you.Validation;
using System.Linq;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Services.Contracts;

namespace VNS.Services
{
    public class FamiliesService : IFamiliesService
    {
        private readonly IEfRepository<Family> familyRepo;

        public FamiliesService(IEfRepository<Family> familyRepo)
        {
            Guard.WhenArgument(familyRepo, "familyRepo").IsNull().Throw();
            this.familyRepo = familyRepo;
        }

        public IQueryable<Family> GetAll()
        {
            return this.familyRepo.All;
        }
    }
}
