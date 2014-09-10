using System;
using System.Linq;
using Inventory.HotelRoom;
using Inventory.Services.Exceptions;
using Inventory.Writes;
using MongoDB.Driver.Linq;

namespace InventoryDataAccess.Repositories
{
    public class RoomBookings : IRoomBookings
    {
        public void Add(int roomId, DateTime checkIn, DateTime checkOut)
        {
            var db = new MongoDbFactory().CreateDb(new Configuration().MongoDbName);

            var rooms = db.GetCollection<Room>("Rooms");

            var room = rooms.AsQueryable().Where(r => r.Id == roomId).First();

            if (room == null)
                throw new NotFoundRoom(string.Format("Room with id - {0} could not be found", roomId));

            room.BookOnDates(checkIn,checkOut);

            rooms.Save(room);
        }
    }
}