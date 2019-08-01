using AutoMapper;
using Knowledge_Garden.Engine.AutoMapper;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Knowledge_Garden.Startup))]
namespace Knowledge_Garden
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // Configure signalR
            app.MapSignalR();
        }
    }
}
