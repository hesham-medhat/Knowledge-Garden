using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.DataEntities.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using Knowledge_Garden.DataEntities;

namespace Knowledge_Garden.DataEntities.DataAccess.Repositories
{
    class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }


        public IEnumerable<Flower> GetNotifications(string employeeUsername)
        {
            IList<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();

            return Context.Notifications
                .Where(n => n.EmployeeUsername == employeeUsername)
                .Select(n => n.Flower)
                .ToList();
        }

        public IEnumerable<Flower> GetNotifications(Employee employee)
        {
            return GetNotifications(employee.Username);
        }
    }
}
