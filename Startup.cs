using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Everest_DVD_Store.Startup))]
namespace Everest_DVD_Store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
