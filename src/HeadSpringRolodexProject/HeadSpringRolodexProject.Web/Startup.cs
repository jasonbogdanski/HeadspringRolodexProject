using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeadSpringRolodexProject.Web.Startup))]
namespace HeadSpringRolodexProject.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
