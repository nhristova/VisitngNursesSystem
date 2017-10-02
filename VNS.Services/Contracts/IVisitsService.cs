using System.Linq;
using VNS.Data.Models;

namespace VNS.Services.Contracts
{
    public interface IVisitsService
    {
        IQueryable<Visit> GetAll();
    }
}