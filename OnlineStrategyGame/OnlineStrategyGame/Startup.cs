using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineStrategyGame.Startup))]
namespace OnlineStrategyGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
