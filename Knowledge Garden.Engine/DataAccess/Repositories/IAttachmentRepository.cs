﻿using Knowledge_Garden.DataEntities;
using Knowledge_Garden.DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataAccess.Repositories
{
    public interface IAttachmentRepository : IRepository<Attachment>
    {
        IEnumerable<string> GetAttachmentNamesOf(Flower flower);
        IEnumerable<string> GetAttachmentNamesOf(int flowerId);
    }
}
