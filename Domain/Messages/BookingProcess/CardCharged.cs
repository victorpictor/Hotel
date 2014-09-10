using System;
using Messages.Markers;

namespace Messages.BookingProcess
{
    public class CardCharged:IEvent
    {
        public Guid Id { get; set; }
    }
}