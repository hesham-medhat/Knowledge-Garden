﻿using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.DataEntities;
using Knowledge_Garden.DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataEntities.DataAccess.Repositories
{
    class TempFileRepository : Repository<TempFile>, ITempFileRepository
    {
        public TempFileRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
