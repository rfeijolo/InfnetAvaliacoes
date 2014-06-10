using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Avaliacoes.Web.Startup))]
namespace Avaliacoes.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
