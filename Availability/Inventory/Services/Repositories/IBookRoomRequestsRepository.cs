using System;
using Inventory.HotelRoom;

namespace Inventory.Services.Repositories
{
    public interface IBookRoomRequestsRepository
    {
        bool Exists(int roomId, DateTime from, DateTime to);
        SubmittedBookRoomRequest Get(Guid id);
    }
}