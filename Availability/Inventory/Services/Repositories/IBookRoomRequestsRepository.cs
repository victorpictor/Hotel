using System;
using Inventory.Holds;

namespace Inventory.Services.Repositories
{
    public interface IBookRoomRequestsRepository
    {
        bool Exists(int roomId, DateTime from, DateTime to);
        SubmittedBookRoomRequest Get(Guid id);
    }
}