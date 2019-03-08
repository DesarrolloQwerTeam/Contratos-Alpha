using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contratos_vers_beta.Startup))]
namespace Contratos_vers_beta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
