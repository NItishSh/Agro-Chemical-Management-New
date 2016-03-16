using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agro_Chemical_Management.Startup))]
namespace Agro_Chemical_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
