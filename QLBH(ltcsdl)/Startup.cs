using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLBH_ltcsdl_.Startup))]
namespace QLBH_ltcsdl_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
