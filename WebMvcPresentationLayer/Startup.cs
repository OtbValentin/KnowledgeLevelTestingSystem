using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMvcPresentationLayer.Startup))]
namespace WebMvcPresentationLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
