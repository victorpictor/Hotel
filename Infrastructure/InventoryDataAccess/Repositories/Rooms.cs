using System.Collections.Generic;
using System.Linq;
using Core.Booking.TheRoom;
using Inventory.Services.Repositories;
using MongoDB.Driver.Linq;
using Room = Inventory.HotelRoom.Room;

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

        public Room Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}