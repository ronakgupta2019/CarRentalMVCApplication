using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarRentalMVCApplication.Startup))]
namespace CarRentalMVCApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
