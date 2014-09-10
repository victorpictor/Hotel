using System;
using Messages.Markers;

namespace Messages.BookingProcess
{
    public class RoomPriced:IEvent
    {
        public Guid Id { get; set; }
    }
}