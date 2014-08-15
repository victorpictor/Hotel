using System;
using Messages.Markers;

namespace Messages.Availability
{
    public class AppliedHoldOnRoom:IEvent
    {
        public int RoomId;

        public Guid Id { get; set; }
    }
}