using System;
using VNS.Data.Models;

namespace VNS.Services.Contracts
{
    public interface IVisitsService
    {
        void Update(Visit visit);

        void Add(Visit visit);

        Visit GetById(Guid? id);
    }
}