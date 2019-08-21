using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.DataEntities;
using Knowledge_Garden.DataEntities.Models;
using System;
using System.Data.Entity;

namespace Knowledge_Garden.DataEntities.DataAccess.Repositories
{
    class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
