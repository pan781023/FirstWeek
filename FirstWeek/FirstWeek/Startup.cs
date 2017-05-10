using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstWeek.Startup))]
namespace FirstWeek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
