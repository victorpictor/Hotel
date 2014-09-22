using System;
using Core.Markers;

namespace Core.BookingProcess
{
    public class AppliedHoldOnRoom:IEvent
    {
       public Guid Id { get; set; }
    }
}