using System.Linq;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Data.SaveContext;
using VNS.Services.Contracts;

namespace VNS.Services
{
    public class UsersService : IUsersService
    {
        private readonly IEfRepository<User> userRepo;
        private readonly ISaveContext context;

        public UsersService(IEfRepository<User> userRepo, ISaveContext context)
        {
            this.userRepo = userRepo;
            this.context = context;
        }
        public User GetByName(string name)
        {
            var test = this.userRepo.All.Where(u => u.UserName == name).First();

            return this.userRepo.All.Where(u => u.UserName == name).First();
        }
    }
}
