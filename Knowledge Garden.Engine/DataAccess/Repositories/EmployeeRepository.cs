using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.Engine.Models;
using System;
using System.Data.Entity;

namespace Knowledge_Garden.Engine.DataAccess.Repositories
{
    class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }


        public void RecordUserActivity(string editorUsername)
        {
            Employee editor = Context.Employees.Find(editorUsername);
            editor.LastContributionTime = DateTime.Now;

            Context.Entry(editor).State = EntityState.Modified;
            Context.Entry(editor).Property(e => e.ApplicationUser).IsModified = false;
            Context.Entry(editor).Property(e => e.Username).IsModified = false;
            Context.Entry(editor).Property(e => e.Flowers).IsModified = false;
            Context.Entry(editor).Property(e => e.Notifications).IsModified = false;
        }

        public void RecordUserActivity(Employee editor)
        {
            RecordUserActivity(editor.Username);
        }
    }
}
