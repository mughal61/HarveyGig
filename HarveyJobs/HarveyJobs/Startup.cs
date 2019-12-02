using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HarveyJobs.Startup))]
namespace HarveyJobs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
