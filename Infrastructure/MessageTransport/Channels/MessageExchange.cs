namespace MessageTransport.Channels
{
    public class MessageExchange
    {
        public MessageExchange(string messageName, string exchangeName)
        {
            MessageName = messageName;
            ExchangeName = exchangeName;
        }

        public string MessageName;
        public string ExchangeName;
    }
}