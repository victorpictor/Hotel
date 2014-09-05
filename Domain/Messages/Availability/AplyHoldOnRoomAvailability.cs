using System;
using Core.TheRoom;
using Messages.Markers;

namespace Messages.Availability
{
    public class AplyHoldOnRoomAvailability:ICommand
    {
        public Guid Id { get; set; }
        
        public RoomType RoomType { get; set; }
        
        public DateTime StartDate;
        public DateTime EndDate;
    }
}