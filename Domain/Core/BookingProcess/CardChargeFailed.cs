using System;
using Core.Markers;

namespace Core.BookingProcess
{
    public class CardChargeFailed : IEvent
    {
        public Guid Id { get; set; }
    }
}