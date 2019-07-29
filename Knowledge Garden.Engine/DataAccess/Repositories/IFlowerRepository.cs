using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataAccess.Repositories
{
    public interface IFlowerRepository
    {
        IEnumerable<Flower> GetNotificationFlowers(Employee employee);
        IEnumerable<Flower> GetNotificationFlowers(string employeeUsername);
        IEnumerable<Flower> GetNotificationFlowers(Employee employee, int pageIndex, int pageSize);
        IEnumerable<Flower> GetNotificationFlowers(string employeeUsername, int pageIndex, int pageSize);

        IEnumerable<Flower> SearchForFlowers(string query);
    }
}
