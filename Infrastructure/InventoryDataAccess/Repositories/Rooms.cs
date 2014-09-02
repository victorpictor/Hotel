using System.Collections.Generic;
using System.Linq;
using Inventory.HotelRoom;
using Inventory.Services.Repositories;
using MongoDB.Driver.Linq;

namespace InventoryDataAccess.Repositories
{
    public class Rooms : IRoomRepository
    {
        public List<Room> Get(RoomType type)
        {
            var db = new MongoDbFactory().CreateDb(new Configuration().MongoDbName);

            var rooms = db.GetCollection<Room>("Rooms");

            return rooms.AsQueryable().Where(r => r.Type == type).ToList();
        }
    }
}