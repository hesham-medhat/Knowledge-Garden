using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.DataAccess.Repositories
{
    class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public int CompleteRequest(int requestId, Flower newFlower)
        {
            return CompleteRequest(Context.Requests.Find(requestId), newFlower);
        }

        public int CompleteRequest(Request request, Flower newFlower)
        {
            if (request == null)
            {
                throw new ArgumentException("Invalid request");
            }
            if (newFlower.OwnerUsername != request.OwnerUsername)
            {
                throw new InvalidOperationException("FORBIDDEN: Cannot complete a request of another user");
            }

            // Map temp files to this flower's attachments
            AutoMapper.BLMapper.GetMapper().Map(request.TempFiles, newFlower.Attachments);

            // Create new flower
            int newFlowerId = Context.Flowers.Add(newFlower).Id;

            // Delete request and temp files
            Context.Requests.Remove(request);

            return newFlowerId;
        }


        public int StartRequest(string ownerUsername)
        {
            Request newRequest = new Request
            {
                OwnerUsername = ownerUsername,
                Timestamp = DateTime.Now
            };

            // Create new request
            int newRequestId = Context.Requests.Add(newRequest).Id;

            return newRequestId;
        }
    }
}
