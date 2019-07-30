using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.Engine.DataAccess.Repositories;

namespace Knowledge_Garden.Engine.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IAttachmentRepository Attachments { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IFlowerRepository Flowers { get; private set; }
        public INotificationRepository Notifications { get; private set; }

        public UnitOfWork (ApplicationDbContext context)
        {
            _context = context;

            Init(_context);
        }

        public UnitOfWork()
        {
            _context = ApplicationDbContext.Create();

            Init(_context);
        }


        private void Init(ApplicationDbContext context)
        {
            Attachments = new AttachmentRepository(context);
            Employees = new EmployeeRepository(context);
            Flowers = new FlowerRepository(context);
            Notifications = new NotificationRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
