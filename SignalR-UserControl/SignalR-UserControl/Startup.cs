using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR_UserControl.Startup))]

namespace SignalR_UserControl
{
    public  class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR(); 
        }      
    }
}
