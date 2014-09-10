using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.HotelRoom;
using Inventory.Services.Repositories;
using MongoDB.Driver.Linq;

namespace InventoryDataAccess.Repositories
{
    public class BookRoomRequests : IBookRoomRequestsRepository
    {
       public bool Exists(int roomId, DateTime @from, DateTime to)
        {
            var db = new MongoDbFactory().CreateDb(new Configuration().MongoDbName);

            var requests = db.GetCollection<SubmittedBookRoomRequest>("BookRoomRequests");

            var unavailable =
                requests.AsQueryable()
                        .Where(r => r.RoomId == roomId)
                        .ToList()
                        .All(r => !((r.StartDate > from && r.StartDate >= to) || (r.EndDate < to && r.EndDate <= from)));
            

            return unavailable;
        }

        public SubmittedBookRoomRequest Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}