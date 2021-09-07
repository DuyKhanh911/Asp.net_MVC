using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(abbccc.Startup))]
namespace abbccc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
