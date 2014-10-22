using System.Collections.Generic;
using System.Linq;
using Core.Markers;
using Core.Sender;
using MessageTransport.Channels;

namespace MessageTransport.Publisher
{
    public class EventPublisher : IEventPublisher
    {
        private List<MessageExchange> exchanges = new List<MessageExchange>();
        private ChannelPublisher publisher = new ChannelPublisher();

        public EventPublisher(List<MessageExchange> exhanges)
        {
            this.exchanges = exhanges;
        }

        public void Publish(IEvent @event)
        {
            publisher.Publish(@event, exchanges.FirstOrDefault(e => e.MessageName == @event.GetType().Name));
        }
    }
}