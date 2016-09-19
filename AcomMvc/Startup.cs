using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcomMvc.Startup))]
namespace AcomMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
