using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Knowledge_Garden.Engine.SignalR
{
    [HubName("notifications")]
    class NotificationsHub : Hub
    {
        public IEnumerable<string> GetUnreadNotifications()
        {
            throw new NotImplementedException("GetUnreadNotifications is not implemented");
        }
    }
}
