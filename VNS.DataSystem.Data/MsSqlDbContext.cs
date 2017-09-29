using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using VNS.DataSystem.Data.Model;
using VNS.DataSystem.Data.Models;

namespace VNS.DataSystem.Data
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Visit> Visits { get; set; }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }
    }
}
