using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Services.Contracts;

namespace VNS.Services
{
    public class MunicipalitiesService : IMunicipalitiesService
    {
        private IEfRepository<Municipality> municipalityRepo;

        public MunicipalitiesService(IEfRepository<Municipality> municipalityRepo)
        {
            Guard.WhenArgument(municipalityRepo, "municipalityRepo").IsNull().Throw();
            this.municipalityRepo = municipalityRepo;
        }

        // TODO: Contains IQueryable<Town> how to conver that to list and where??
        public ICollection<Municipality> GetAll()
        {
            return this.municipalityRepo.All.ToList();
        }
    }
}
