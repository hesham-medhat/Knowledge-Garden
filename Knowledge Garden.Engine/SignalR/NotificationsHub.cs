using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Knowledge_Garden.Engine.DataAccess;
using Knowledge_Garden.Engine.DataAccess.Repositories;

namespace Knowledge_Garden.Engine.SignalR
{
    [HubName("notifications")]
    class NotificationsHub : Hub
    {
        public IEnumerable<KeyValuePair<int, string>> GetUnreadNotifications()
        {
            string username = Context.User.Identity.Name;
            
            IUnitOfWork uow = new UnitOfWork();

            var returner = uow.Notifications.GetNotifications(username);

            uow.SaveAndDispose();

            return returner;
        }
    }
}
