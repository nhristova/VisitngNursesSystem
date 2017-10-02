using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VNS.Web.Startup))]
namespace VNS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
