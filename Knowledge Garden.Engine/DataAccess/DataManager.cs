using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.DataAccess
{
    public class DataManager
    {
        private static DataManager _instance = null;
        private static readonly object _padlock = new object();

        private ApplicationDbContext db = new ApplicationDbContext();

        private DataManager()
        {
            // Private constructor to prevent instantiation implementing Singleton design pattern
        }

        public static DataManager Instance()
        {
            if (_instance == null)
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        return _instance = new DataManager();
                    }
                }
            }
            return _instance;
        }


        public Flower GetFlower(int id, bool loadOwner = false)
        {
            Flower flower = db.Flowers.Find(id);
            if (flower != null)
            {
                if (loadOwner)
                {
                    db.Entry(flower).Reference(f => f.Owner).Load();
                }
            }
            return flower;
        }

        public IEnumerable<Flower> GetAllFlowers()
        {
            return db.Flowers.ToList();
        }

        public Employee GetEmployee(string name)
        {
            return db.Employees.Find(name);
        }

        public void AddFlower(string editorUsername, string problem, string solution, string title)
        {
            var flower = new Flower
            {
                LastUpdateDate = DateTime.Now,
                Owner = db.Employees.Find(editorUsername),
                Problem = problem,
                Solution = solution,
                Title = title
            };
            db.Flowers.Add(flower);

            RecordUserActivity(editorUsername);

            db.SaveChanges();
        }

        public void EditFlower(string editorUsername, int flowerId, string problem, string solution, string title)
        {
            Flower flower = GetFlower(flowerId);
            flower.Problem = problem;
            flower.Solution = solution;
            flower.Title = title;
            flower.LastUpdateDate = DateTime.Now;
            
            db.Entry(flower).State = EntityState.Modified;
            db.Entry(flower).Property(f => f.Owner).IsModified = false;
            db.Entry(flower).Property(f => f.Id).IsModified = false;

            RecordUserActivity(editorUsername);

            db.SaveChanges();
        }

        public void RemoveFlower(int id)
        {
            Flower flower = db.Flowers.Find(id);
            db.Flowers.Remove(flower);
        }

        private void RecordUserActivity(string editorUsername)
        {
            Employee editor = db.Employees.Find(editorUsername);
            editor.LastContributionTime = DateTime.Now;

            db.Entry(editor).State = EntityState.Modified;
            db.Entry(editor).Property(e => e.UserId).IsModified = false;
            db.Entry(editor).Property(e => e.Username).IsModified = false;
            db.Entry(editor).Property(e => e.Flowers).IsModified = false;
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
