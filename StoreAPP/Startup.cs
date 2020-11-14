using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreApp.Startup))]
namespace StoreApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
