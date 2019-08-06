﻿using Knowledge_Garden.DataAccess.Repositories;
using Knowledge_Garden.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.DataAccess.Repositories
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
        int CompleteRequest(Request request, Flower newFlower);
        /// <returns>Newly created flower's identifier</returns>
        int CompleteRequest(int requestId, Flower newFlower);
    }
}