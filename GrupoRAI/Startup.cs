using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrupoRAI.Startup))]
namespace GrupoRAI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
