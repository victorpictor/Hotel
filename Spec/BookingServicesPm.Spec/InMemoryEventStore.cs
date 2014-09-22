using System;
using System.Collections.Generic;
using System.Linq;
using Core.Markers;
using Core.Store;

namespace BookingServicesPm.Spec
{
    public class InMemoryEventStore : IEventStore
    {
        public List<IEvent> EventStore = new List<IEvent>();

        public List<IEvent> LoadStream(Guid streamId)
        {
            return EventStore.Where(e => e.Id == streamId).ToList();
        }

        public void AppendToStream(Guid streamId, IEvent ev)
        {
            EventStore.Add(ev);
        }

        public void AppendToStream(Guid streamId, List<IEvent> evs)
        {
            EventStore.AddRange(evs);
        }
    }
}