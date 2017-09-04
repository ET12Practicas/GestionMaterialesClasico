using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gestionmateriales.Startup))]
namespace gestionmateriales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
