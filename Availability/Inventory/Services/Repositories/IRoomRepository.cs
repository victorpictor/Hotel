using System.Collections.Generic;
using Core.TheRoom;
using Room = Inventory.HotelRoom.Room;

namespace Inventory.Services.Repositories
{
    public interface IRoomRepository
    {
        List<Room> Get(RoomType type);
    }
}