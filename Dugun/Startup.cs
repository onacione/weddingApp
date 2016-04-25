using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dugun.Startup))]
namespace Dugun
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
