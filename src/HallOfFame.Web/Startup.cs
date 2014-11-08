using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HallOfFame.Web.Startup))]

namespace HallOfFame.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
