using Knowledge_Garden.DataEntities;
using Knowledge_Garden.DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataAccess.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
        /// <summary>
        /// Gets the FlowerId and Title of each flower in employee's unread notifications
        /// </summary>
        /// <returns>KeyValuePair where the key is the FlowerId and the value is its title</returns>
        IEnumerable<Flower> GetNotifications(Employee employee);
        IEnumerable<Flower> GetNotifications(string employeeUsername);
    }
}
