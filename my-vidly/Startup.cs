using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(my_vidly.Startup))]
namespace my_vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
