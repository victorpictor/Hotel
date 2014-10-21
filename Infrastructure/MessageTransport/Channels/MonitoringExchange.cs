using System.Collections.Generic;
using RabbitMQ.Client;

namespace MessageTransport.Channels
{
    public class MonitoringExchange
    {
        public MonitoringExchange(string exchangeName, List<MessageExchange> messageExchanges)
        {
            var factory = new ConnectionFactory { HostName = Config.Host };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);

                    messageExchanges.ForEach(e => channel.ExchangeBind(exchangeName, e.ExchangeName, string.Empty));
                }
            }
        }
    }
}