using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.DataEntities;
using Knowledge_Garden.DataEntities.Models;
using Knowledge_Garden.DataEntities.SignalR;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataEntities.DataAccess.Repositories
{
    class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CompleteRequest(int requestId, string editorUsername, string problem, string solution, string title)
        {
            CompleteRequest(Context.Requests.Find(requestId), editorUsername, problem, solution, title);
        }

        public void CompleteRequest(Request request, string editorUsername, string problem, string solution, string title)
        {
            if (request == null)
            {
                throw new ArgumentException("Invalid request");
            }
            if (editorUsername != request.OwnerUsername)
            {
                throw new InvalidOperationException("FORBIDDEN: Cannot complete a request of another user");
            }

            Flower newFlower = new Flower
            {
                LastUpdateDate = DateTime.Now,
                OwnerUsername = editorUsername,
                Problem = problem,
                Solution = solution,
                Title = title
            };

            newFlower.Attachments = new List<Attachment>();

            // Map temp files to this flower's attachments
            AutoMapper.BLMapper.GetMapper().Map(request.TempFiles, newFlower.Attachments);

            // Create new flower
            Context.Flowers.Add(newFlower);

            // Delete request and temp files
            Context.Requests.Remove(request);

            // Save changes to send notification to all clients
            Context.SaveChanges();


            /* Notify online clients with SignalR */
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();

            /* Prepare parameter */
            FlowerBL parameter = new FlowerBL();
            AutoMapper.BLMapper.GetMapper().Map(newFlower, parameter);

            hubContext.Clients.All.receiveNotification(parameter);
        }


        public int StartRequest(string ownerUsername)
        {
            Request newRequest = new Request
            {
                OwnerUsername = ownerUsername,
                Timestamp = DateTime.Now
            };

            // Create new request
            Context.Requests.Add(newRequest);
            Context.SaveChanges();

            return newRequest.Id;
        }
    }
}
