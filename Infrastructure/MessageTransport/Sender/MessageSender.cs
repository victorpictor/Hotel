using System.Collections.Generic;
using System.Linq;
using Core.Markers;
using Core.Sender;
using MessageTransport.Channels;
using MessageTransport.Subscriptions;

namespace MessageTransport.Sender
{
    public class MessageSender:ICommandSerder
    {
        private List<MessageExchange> exchanges = new SubscriptionStorage().AllMessageExchanges();
        private ChannelPublisher publisher = new ChannelPublisher();

        public void Send(ICommand command)
        {
            publisher.Publish(command, exchanges.FirstOrDefault(e => e.MessageName == command.GetType().Name));
        }
    }
}