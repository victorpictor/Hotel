using System.Collections.Generic;
using System.Linq;
using MessageTransport.Subscriptions;

namespace MessageTransport.Channels
{
    public class MessagingInfrastructure
    {
        private List<MessageExchange> exchanges;

        
        public MessagingInfrastructure SetExchanges(List<MessageExchange> exchanges)
        {
            this.exchanges = exchanges;

            exchanges.ForEach(e => new ExchangeSetup(e.ExchangeName, ExchangeType.Topic));

            exchanges.ForEach(e => new QueuesSetup(e.ExchangeName, e.MessageName));

            exchanges.ForEach(e => new SubscriptionStorage().Store(e));
           
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