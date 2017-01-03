using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FurnitureWizardDemo.Startup))]
namespace FurnitureWizardDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
