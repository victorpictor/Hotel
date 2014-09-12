using System;
using Core.Markers;

namespace Core.BookingProcess
{
    public class RoomPriced:IEvent
    {
        public Guid Id { get; set; }
    }
}