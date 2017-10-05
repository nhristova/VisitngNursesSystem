using System.Collections.Generic;
using VNS.Data.Models;

namespace VNS.Services.Contracts
{
    public interface IMunicipalitiesService
    {
        ICollection<Municipality> GetAll();
    }
}
