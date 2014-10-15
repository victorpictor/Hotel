using System;
using Core.Markers;

namespace EventsStore.StreamReader
{
    public class EventDescriptor
    {
        public Guid Id = Guid.NewGuid();

        public EventDescriptor()
        {
        }

        public EventDescriptor(IEvent e)
        {
            StreamId = e.Id;
            Event = e;
        }

        public EventDescriptor(Guid streamId, IEvent e)
        {
            StreamId = streamId;
            Event = e;
        }

        public Guid StreamId { get; set; }
        public IEvent Event { get; set; }
    
    }
}