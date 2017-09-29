using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VNS.DataSystem.Web.Startup))]
namespace VNS.DataSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
