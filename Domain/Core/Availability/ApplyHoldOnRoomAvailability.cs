using System;
using Core.Booking.TheRoom;
using Core.Markers;

namespace Messages.Availability
{
    public class ApplyHoldOnRoomAvailability:ICommand
    {
        public Guid Id { get; set; }
        
        public RoomType RoomType { get; set; }
        
        public DateTime StartDate;
        public DateTime EndDate;
    }
}