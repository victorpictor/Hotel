using System;
using Core.Markers;

namespace Core.Availability
{
    public class AppliedHoldOnRoom:IEvent
    {
        public int RoomId;

        public Guid Id { get; set; }
    }
}