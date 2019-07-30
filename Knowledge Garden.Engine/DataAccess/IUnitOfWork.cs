using Knowledge_Garden.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        /* Repositories */
        IAttachmentRepository Attachments { get; }
        IEmployeeRepository Employees { get; }
        IFlowerRepository Flowers { get; }
        INotificationRepository Notifications { get; }

        /* Save */
        int Save();
    }
}
