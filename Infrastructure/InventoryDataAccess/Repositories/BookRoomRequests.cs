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

            var unavailable = requests.AsQueryable().Where(r => r.Id == roomId && !(r.StartDate.Date > from && r.StartDate.Date >= to) ||
                                              (r.EndDate.Date < to && r.EndDate.Date <= from));

            return unavailable.Any();
        }
    }
}