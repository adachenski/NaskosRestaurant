using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restorant.Web.Startup))]

namespace Restorant.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
