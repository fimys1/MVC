using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StomatologyMVC.Startup))]
namespace StomatologyMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
