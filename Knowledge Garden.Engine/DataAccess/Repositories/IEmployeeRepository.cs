﻿using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataAccess.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void RecordUserActivity(Employee editor);

        void RecordUserActivity(string editorUsername);
    }
}