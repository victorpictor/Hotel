using System;
using Core.Booking.TheRoom;
using Core.Markers;

namespace Core.Pricing
{
    public class GetRoomPrice:ICommand
    {
        public Guid Id { get; set; }
        public RoomType RoomType { get; set; }

        public DateTime StartDate;
        public DateTime EndDate;
    }
}