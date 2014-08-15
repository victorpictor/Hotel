using System;
using Messages.Markers;

namespace Messages.Availability
{
    public class AplyHoldOnRoomAvailability:ICommand
    {
        public Guid Id { get; set; }

        public DateTime StartDate;
        public DateTime EndDate;
    }
}