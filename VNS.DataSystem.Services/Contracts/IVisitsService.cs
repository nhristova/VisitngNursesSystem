using System.Linq;
using VNS.DataSystem.Data.Models;

namespace VNS.DataSystem.Services.Contracts
{
    public interface IVisitsService
    {
        IQueryable<Visit> GetAll();
    }
}