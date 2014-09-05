using System;

namespace Inventory.Services.Repositories
{
    public interface IBookRoomRequestsRepository
    {
        bool Exists(int roomId, DateTime from, DateTime to);
    }
}