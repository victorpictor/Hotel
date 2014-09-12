using System;
using Core.Booking.TheRoom;

namespace Inventory.HotelRoom
{
    public class SubmittedBookRoomRequest
    {
        public Guid Id;
        public int RoomId;
        public RoomType RoomType;
        public DateTime StartDate;
        public DateTime EndDate;
    }
}