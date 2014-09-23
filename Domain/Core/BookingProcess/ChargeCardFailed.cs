using System;
using Core.Markers;

namespace Core.BookingProcess
{
    public class ChargeCardFailed : IEvent
    {
        public Guid Id { get; set; }
    }
}