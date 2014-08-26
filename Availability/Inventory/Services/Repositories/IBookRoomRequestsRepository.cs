using System;
using System.Collections.Generic;
using Inventory.Holds;

namespace Inventory.Services.Repositories
{
    public interface IBookRoomRequestsRepository
    {
        bool Exists(int roomId, DateTime from, DateTime to);
        List<SubmittedBookRoomRequest> Get();
    }
}