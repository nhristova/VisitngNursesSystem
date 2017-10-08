using VNS.Data.Models;

namespace VNS.Services.Contracts
{
    public interface IUsersService
    {
        User GetByName(string name);
    }
}
