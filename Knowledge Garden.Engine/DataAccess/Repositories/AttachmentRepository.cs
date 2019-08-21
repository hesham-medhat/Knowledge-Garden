using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.DataEntities;
using Knowledge_Garden.DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataEntities.DataAccess.Repositories
{
    class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(ApplicationDbContext context) : base(context)
        {
        }


        public IEnumerable<string> GetAttachmentNamesOf(int flowerId)
        {
            return Context.Attachments
                .Where(a => a.FlowerId == flowerId)
                .Select(a => a.Name)
                .ToList();
        }

        public IEnumerable<string> GetAttachmentNamesOf(Flower flower)
        {
            return GetAttachmentNamesOf(flower.Id);
        }
    }
}
