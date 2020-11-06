using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sahab.Enterprise.HR.Startup))]
namespace Sahab.Enterprise.HR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
