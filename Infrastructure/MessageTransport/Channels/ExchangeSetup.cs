using RabbitMQ.Client;

namespace MessageTransport.Channels
{
    public class ExchangeSetup
    {
        public ExchangeSetup(string exchangeName, string exchangeType)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchangeName, exchangeType, true, false, null);
                }
            }
        }
    }
}