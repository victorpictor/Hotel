using System;
using System.Collections.Generic;
using Core.Markers;
using Core.Store;

namespace EventsStore.StreamReader
{
    public class EventStore : IEventStore
    {
        public List<IEvent> LoadStream(Guid streamId)
        {
            throw new NotImplementedException();
        }

        public void AppendToStream(Guid streamId, IEvent ev)
        {
            throw new NotImplementedException();
        }

        public void AppendToStream(Guid streamId, List<IEvent> evs)
        {
            throw new NotImplementedException();
        }
    }
}