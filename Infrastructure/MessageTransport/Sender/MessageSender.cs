using System.Collections.Generic;
using Core.Markers;
using Core.Sender;
using MessageTransport.Channels;

namespace MessageTransport.Sender
{
    public class MessageSender:ICommandSerder
    {
        private List<MessageExchange> exchanges = new List<MessageExchange>();

        public MessageSender(List<MessageExchange> exchanges)
        {
            this.exchanges = exchanges;
        }

        public void Send(ICommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}