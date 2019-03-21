using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CalumBSUAttempt2.Startup))]
namespace CalumBSUAttempt2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
