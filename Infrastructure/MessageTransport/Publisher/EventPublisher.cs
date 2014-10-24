using System.Collections.Generic;
using System.Linq;
using Core.Markers;
using Core.Sender;
using MessageTransport.Channels;
using MessageTransport.Subscriptions;

namespace MessageTransport.Publisher
{
    public class EventPublisher : IEventPublisher
    {
        private List<MessageExchange> exchanges = new SubscriptionStorage().AllMessageExchanges();
        private ChannelPublisher publisher = new ChannelPublisher();

        public void Publish(IEvent @event)
        {
            publisher.Publish(@event, exchanges.FirstOrDefault(e => e.MessageName == @event.GetType().Name));
        }
    }
}