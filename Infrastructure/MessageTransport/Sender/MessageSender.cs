using System.Collections.Generic;
using System.Linq;
using Core.Markers;
using Core.Sender;
using MessageTransport.Channels;

namespace MessageTransport.Sender
{
    public class MessageSender:ICommandSerder
    {
        private List<MessageExchange> exchanges = new List<MessageExchange>();
        private ChannelPublisher publisher = new ChannelPublisher();

        public MessageSender(List<MessageExchange> exchanges)
        {
            this.exchanges = exchanges;
        }

        public void Send(ICommand command)
        {
            publisher.Publish(command, exchanges.FirstOrDefault(e => e.MessageName == command.GetType().Name));
        }
    }
}