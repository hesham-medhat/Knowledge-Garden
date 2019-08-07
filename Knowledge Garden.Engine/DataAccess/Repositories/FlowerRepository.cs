using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.Engine.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Knowledge_Garden.Engine.DataAccess.Repositories
{
    class FlowerRepository : Repository<Flower>, IFlowerRepository
    {
        public FlowerRepository(ApplicationDbContext context) : base(context)
        {
        }


        public Flower GetFlower(int id)
        {
            return Find(id);
        }

        public IEnumerable<Flower> GetAllFlowers()
        {
            return GetAll();
        }

        public void RemoveFlower(int deletedFlowerId)
        {
            Remove(
                Find(deletedFlowerId) // Flower entity to be deleted
                );
        }

        public void EditFlower(string editorUsername, int flowerId, string problem, string solution, string title)
        {
            bool edited = false;

            Flower flower = Find(flowerId);

            if (flower.Problem != problem)
            {
                edited = true;
                flower.Problem = problem;
            }

            if (flower.Solution != solution)
            {
                edited = true;
                flower.Solution = solution;
            }

            if (flower.Title != title)
            {
                edited = true;
                flower.Title = title;
            }

            if (!edited)
            {
                return;
            }

            /* Indeed edited something at this point */
            flower.LastUpdateDate = DateTime.Now;

            Context.Entry(flower).State = EntityState.Modified;
        }

        public IEnumerable<Flower> GetNotificationFlowers(string employeeUsername)
        {
            return Context.Notifications
                .Where(n => n.EmployeeUsername == employeeUsername)
                .Select(n => n.Flower)
                .ToList();
        }

        public IEnumerable<Flower> GetNotificationFlowers(Employee employee)
        {
            return GetNotificationFlowers(employee.Username);
        }

        public IEnumerable<Flower> GetNotificationFlowers(string employeeUsername, int pageIndex, int pageSize)
        {
            return Context.Notifications
                .Where(n => n.EmployeeUsername == employeeUsername)
                .Select(n => n.Flower)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .ToList();
        }

        public IEnumerable<Flower> GetNotificationFlowers(Employee employee, int pageIndex, int pageSize)
        {
            return GetNotificationFlowers(employee.Username, pageIndex, pageSize);
        }

        public IEnumerable<Flower> SearchForFlowers(string query)
        {
            throw new NotImplementedException();
        }
    }
}
