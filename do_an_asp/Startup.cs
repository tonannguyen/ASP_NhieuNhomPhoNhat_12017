using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(do_an_asp.Startup))]
namespace do_an_asp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
