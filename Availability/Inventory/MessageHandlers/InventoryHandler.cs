using Core.Availability;
using Core.BookingProcess;
using Core.MessageReceiver;
using Core.Sender;
using Inventory.HotelRoom;
using Inventory.Services.Repositories;
using Inventory.Writes;
using Messages.Availability;

namespace Inventory.MessageHandlers
{
    public class InventoryHandler : 
        IReceiveMessage<ApplyHoldOnRoomAvailability>, 
        IReceiveMessage<MarkRoomBooked>
    {
        private IBookRoomRequests bookRoomRequests;
        private IBookRoomRequestsRepository bookRoomRequestsCollection;
        private IRoomBookings roomBookings;
        private IEventPublisher bus;

        public InventoryHandler(IEventPublisher bus,
                                IBookRoomRequests bookRoomRequests,
                                IBookRoomRequestsRepository bookRoomRequestsCollection,
                                IRoomBookings roomBookings)
        {
            this.bus = bus;
            this.bookRoomRequests = bookRoomRequests;
            this.bookRoomRequestsCollection = bookRoomRequestsCollection;
            this.roomBookings = roomBookings;
        }

        public void Receive(ApplyHoldOnRoomAvailability c)
        {
            bookRoomRequests.Add(new SubmittedBookRoomRequest()
            {
                Id = c.Id,
                RoomType = c.RoomType,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
            });

            bus.Publish(new AppliedHoldOnRoom() { Id = c.Id });
        }

        public void Receive(MarkRoomBooked c)
        {
            var r = bookRoomRequestsCollection.Get(c.Id);

            roomBookings.Add(r.RoomId, r.StartDate, r.EndDate);
        }
    }
}