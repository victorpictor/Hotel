using Inventory.Holds;
using Inventory.Services.Repositories;
using Messages.Availability;

namespace InventoryServiceHost.Commands
{
    public class InventoryHandler
    {
        private IBookRoomRequests bookRoomRequests;
        private IBookRoomRequestsRepository bookRoomRequestsCollection;
        private IRoomRepository roomsCollection;

        public void Handle(AplyHoldOnRoomAvailability c)
        {
            //Get a room by type assigned to request
            //Add verification if the room is still available
            bookRoomRequests.Add(new SubmittedBookRoomRequest()
                {
                    Id = c.Id,
                    RoomType = c.RoomType,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                });
        }

        public void Handle(MarkRoomBooked c)
        {
            //Get BookRoomRequest by correlation id
            var r = bookRoomRequestsCollection.Get(c.Id);
            //Get room and book it on given dates
            var theRoom = roomsCollection.Get(r.RoomId);
            theRoom.BookOnDates(r.StartDate,r.EndDate);
            
            //store changes

        }
    }
}