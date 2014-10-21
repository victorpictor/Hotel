using System.Collections.Generic;
using System.Linq;

namespace MessageTransport.Channels
{
    public class MessagingInfrastructure
    {
        private List<MessageExchange> exchanges;

        
        public MessagingInfrastructure SetExchanges(List<MessageExchange> exchanges)
        {
            this.exchanges = exchanges;

            exchanges.ForEach(e => new ExchangeSetup(e.ExchangeName, ExchangeType.Fanout));

            exchanges.ForEach(e => new QueuesSetup(e.ExchangeName, e.MessageName));

            return this;
        }

        public MessagingInfrastructure SetMonitoring(string destinationExchange)
        {
            if (exchanges.Any())
                new MonitoringExchange(destinationExchange, exchanges);

            return this;
        }
    }
}