using Inventory.HotelRoom;
using Inventory.Writes;

namespace InventoryDataAccess.Repositories
{
    public class SubmittedBookRoomRequests : IBookRoomRequests
    {
        public void Add(SubmittedBookRoomRequest request)
        {
            var db = new MongoDbFactory().CreateDb(new Configuration().MongoDbName);

            var requests = db.GetCollection<SubmittedBookRoomRequest>("BookRoomRequests");

            requests.Save(request);
        }
    }
}