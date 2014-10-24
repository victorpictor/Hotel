using System;

namespace MessageTransport.Channels
{
    public class MessageExchange
    {
        public MessageExchange(string messageName, string exchangeName)
        {
            MessageName = messageName;
            ExchangeName = exchangeName;
        }

        public Guid Id = Guid.NewGuid();

        public string MessageName;
        public string ExchangeName;
    }
}