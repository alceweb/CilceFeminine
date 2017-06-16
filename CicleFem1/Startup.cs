using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CicleFem1.Startup))]
namespace CicleFem1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
