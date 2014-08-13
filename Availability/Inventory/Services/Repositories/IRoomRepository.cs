using System.Collections.Generic;
using Inventory.HotelRoom;

namespace Inventory.Services.Repositories
{
    public interface IRoomRepository
    {
        List<Room> Get(RoomType type);
    }
}