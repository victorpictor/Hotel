using System;
using Core.Markers;

namespace Core.BookingProcess
{
    public class CardCharged:IEvent
    {
        public Guid Id { get; set; }
    }
}