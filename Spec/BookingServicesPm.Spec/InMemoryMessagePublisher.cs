using System.Collections.Generic;
using Core.Markers;
using Core.Sender;

namespace BookingServicesPm.Spec
{
    public class InMemoryMessagePublisher : IEventPublisher
    {
        public List<IEvent> Published = new List<IEvent>();
        
        public void Publish(IEvent @event)
        {
            Published.Add(@event);
        }
    }
}