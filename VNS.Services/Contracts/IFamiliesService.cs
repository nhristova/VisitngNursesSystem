using System.Linq;
using VNS.Data.Models;

namespace VNS.Services.Contracts
{
    public interface IFamiliesService
    {
        IQueryable<Family> GetAll();
    }
}