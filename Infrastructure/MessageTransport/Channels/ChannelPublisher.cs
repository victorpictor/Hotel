using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MessageTransport.Channels
{
    public class ChannelPublisher
    {
        public void Publish<T>(T message, MessageExchange exchange)
        {
            var factory = new ConnectionFactory() { HostName = Config.Host };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclarePassive(exchange.MessageName);

                    var messageSerialized = JsonConvert.SerializeObject(message);

                    var body = Encoding.UTF8.GetBytes(messageSerialized);

                    channel.BasicPublish(exchange.ExchangeName, "", null, body);
                }
            }
        }
    }
}