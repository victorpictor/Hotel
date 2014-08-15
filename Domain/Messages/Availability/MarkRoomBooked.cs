using System;
using Messages.Markers;

namespace Messages.Availability
{
    public class MarkRoomBooked:ICommand
    {
        public Guid Id { get; set; }
    }
}