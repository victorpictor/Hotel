using System;
using Inventory.Services.Repositories;
using Inventory.Writes;

namespace Inventory.Services
{
    public class BookingService
    {
        private IBookRoomRequestsRepository bookRoomRequestsCollection;
        private IRoomBookings bookingsCollection;

        public void BookRoom(Guid requestId)
        {
            var r = bookRoomRequestsCollection.Get(requestId);

            bookingsCollection.Add(r.RoomId,r.StartDate, r.EndDate);
            
        }
    }
}