using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BTVN_TH.Startup))]
namespace BTVN_TH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
