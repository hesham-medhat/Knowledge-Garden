using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataAccess.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
        IEnumerable<string> GetNotificationsTitles(Employee employee);
        IEnumerable<string> GetNotificationsTitles(string employeeUsername);
    }
}
