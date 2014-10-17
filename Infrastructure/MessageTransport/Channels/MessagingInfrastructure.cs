using System.Collections.Generic;

namespace MessageTransport.Channels
{
    public class MessagingInfrastructure
    {
        public MessagingInfrastructure(List<MessageExchange> exhanges)
        {
            exhanges.ForEach(e => new ExchangeSetup(e.ExchangeName, ExchangeType.Fanout));

            exhanges.ForEach(e => new QueuesSetup(e.MessageName, e.ExchangeName));
        } 
    }
}