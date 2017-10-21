using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dreport.Startup))]
namespace dreport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
