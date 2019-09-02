using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarmTradeApp.Startup))]
namespace FarmTradeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
