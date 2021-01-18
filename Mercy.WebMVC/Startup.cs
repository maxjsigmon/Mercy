using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mercy.WebMVC.Startup))]
namespace Mercy.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
