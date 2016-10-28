using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PhotoSharingApplication.Startup))]
namespace PhotoSharingApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
