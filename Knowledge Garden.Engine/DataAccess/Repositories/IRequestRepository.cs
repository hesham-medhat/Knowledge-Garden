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
    public interface IRequestRepository : IRepository<Request>
    {
        /// <summary>
        /// Issues and initiates a new request in the name of the given username
        /// </summary>
        /// <param name="ownerUsername">The owner who issued this request</param>
        /// <returns>New request's identifier</returns>
        int StartRequest(string ownerUsername);


        /// <returns>Newly created flower's identifier</returns>
        void CompleteRequest(int requestId, string editorUsername, string problem, string solution, string title);
        /// <returns>Newly created flower's identifier</returns>
        void CompleteRequest(Request request, string editorUsername, string problem, string solution, string title);
    }
}
