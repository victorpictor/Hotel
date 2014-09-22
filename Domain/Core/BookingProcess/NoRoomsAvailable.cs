using System;
using Core.Markers;

namespace Core.BookingProcess
{
    public class NoRoomsAvailable : IEvent
    {
        public Guid Id { get; set; }
    }
}