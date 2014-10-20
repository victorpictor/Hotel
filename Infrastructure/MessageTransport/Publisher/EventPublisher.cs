using System.Collections.Generic;
using Core.Markers;
using Core.Sender;
using MessageTransport.Channels;

namespace MessageTransport.Publisher
{
    public class EventPublisher : IEventPublisher
    {
        private List<MessageExchange> exchanges = new List<MessageExchange>();

        public EventPublisher(List<MessageExchange> exhanges)
        {
            this.exchanges = exhanges;
        }

        public void Publish(IEvent @event)
        {
            throw new System.NotImplementedException();
        }
    }
}