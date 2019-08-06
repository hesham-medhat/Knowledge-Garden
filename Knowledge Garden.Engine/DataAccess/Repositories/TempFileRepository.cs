using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.DataAccess.Repositories
{
    class TempFileRepository : Repository<TempFile>, ITempFileRepository
    {
        public TempFileRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
