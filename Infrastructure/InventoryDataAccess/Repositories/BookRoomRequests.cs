using System;
using System.Collections.Generic;
using Inventory.Holds;
using Inventory.Services.Repositories;

namespace InventoryDataAccess.Repositories
{
    public class BookRoomRequests : IBookRoomRequestsRepository
    {
        public List<SubmittedBookRoomRequest> Get()
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int roomId, DateTime @from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Guid roomId, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}