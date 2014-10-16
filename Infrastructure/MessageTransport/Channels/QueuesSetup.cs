using RabbitMQ.Client;

namespace MessageTransport.Channels
{
    public class QueuesSetup
    {
        public QueuesSetup(string exchangeName, string queueName)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, true, false, false, null);

                    channel.QueueBind(queueName, exchangeName, string.Empty);
                }
            }
        }
    }
}