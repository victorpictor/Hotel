using System.Collections.Generic;
using Inventory.HotelRoom;
using Inventory.Services.Repositories;

namespace InventoryDataAccess.Repositories
{
    public class Rooms : IRoomRepository
    {
        public List<Room> Get(RoomType type)
        {
            throw new System.NotImplementedException();
        }
    }
}