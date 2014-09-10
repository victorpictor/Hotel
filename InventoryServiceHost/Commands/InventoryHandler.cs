using Inventory.HotelRoom;
using Inventory.Services.Repositories;
using Inventory.Writes;
using Messages.Availability;

namespace InventoryServiceHost.Commands
{
    public class InventoryHandler
    {
        private IBookRoomRequests bookRoomRequests;
        private IBookRoomRequestsRepository bookRoomRequestsCollection;
        private IRoomBookings roomBookings;

        public InventoryHandler(IBookRoomRequests bookRoomRequests,
                                IBookRoomRequestsRepository bookRoomRequestsCollection, 
                                IRoomBookings roomBookings)
        {
            this.bookRoomRequests = bookRoomRequests;
            this.bookRoomRequestsCollection = bookRoomRequestsCollection;
            this.roomBookings = roomBookings;
        }

        public void Handle(AplyHoldOnRoomAvailability c)
        {
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
            var r = bookRoomRequestsCollection.Get(c.Id);
            
            roomBookings.Add(r.RoomId, r.StartDate,r.EndDate);
        }
    }
}