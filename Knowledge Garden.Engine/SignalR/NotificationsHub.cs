using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Knowledge_Garden.Engine.DataAccess;
using Knowledge_Garden.Engine.Models;
using AutoMapper;

namespace Knowledge_Garden.Engine.SignalR
{
    public class NotificationsHub : Hub
    {
        private IUnitOfWork uow = new UnitOfWork();

        public IEnumerable<FlowerBL> GetUnreadNotifications()
        {
            string username = Context.User.Identity.Name;

            var flowers = uow.Notifications.GetNotifications(username);

            IEnumerable<FlowerBL> returner = new List<FlowerBL>();
            AutoMapper.BLMapper.GetMapper().Map(flowers, returner);

            return returner;
        }
    }
}
