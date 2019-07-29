using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.Engine.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Knowledge_Garden.Engine.DataAccess.Repositories
{
    class NotificationsRepository : Repository<Notification>, INotificationsRepository
    {
        public NotificationsRepository(ApplicationDbContext context) : base(context)
        {
        }


        public IEnumerable<string> GetNotificationsTitles(string employeeUsername)
        {
            return Context.Notifications
                .Where(n => n.EmployeeUsername == employeeUsername)
                .Select(n => n.Flower.Title)
                .ToList();
        }

        public IEnumerable<string> GetNotificationsTitles(Employee employee)
        {
            return GetNotificationsTitles(employee.Username);
        }
    }
}
