using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ClickTickerSample.Startup))]
namespace ClickTickerSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}