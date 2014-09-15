using System;
using System.Collections.Generic;
using Core.Markers;

namespace Core.Store
{
    public interface IEventStore
    {
        List<IEvent> LoadStream(Guid streamId);

        void AppendToStream(Guid streamId, IEvent ev);
        void AppendToStream(Guid streamId, List<IEvent> evs);
    }
}