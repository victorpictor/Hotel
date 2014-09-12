using System;
using Core.Markers;

namespace Core.Availability
{
    public class MarkRoomBooked:ICommand
    {
        public Guid Id { get; set; }
    }
}