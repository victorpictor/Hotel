using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.Holds;
using Inventory.Services.Repositories;
using MongoDB.Driver.Linq;

namespace InventoryDataAccess.Repositories
{
    public class BookRoomRequests : IBookRoomRequestsRepository
    {
        public List<SubmittedBookRoomRequest> Get()
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int roomId, DateTime @from, DateTime to)
        {
            var db = new MongoDbFactory().CreateDb(new Configuration().MongoDbName);

            var requests = db.GetCollection<SubmittedBookRoomRequest>("SubmittedBookRoomRequests");

            var unavailable = requests.AsQueryable().Where(r => r.Id == roomId && !(r.StartDate > from && r.StartDate >= to) ||
                                              (r.EndDate < to && r.EndDate <= from)).ToList();

            return unavailable.Any();
        }
    }
}