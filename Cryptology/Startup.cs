using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cryptology.Startup))]
namespace Cryptology
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
