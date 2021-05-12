using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartGroceryList2._0MVC.Startup))]
namespace SmartGroceryList2._0MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
