using System;
using RabbitMQ.Client;

namespace MessageTransport.Channels
{
    public class QueuesSetup
    {
       public QueuesSetup(string exchangeName, string queueName)
        {
            var factory = new ConnectionFactory { HostName =  Config.Host };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    try
                    {
                        channel.QueueDeclare(queueName, true, false, false, null);
                    }
                    catch (Exception)
                    {
                    }
                    
                    channel.QueueBind(queueName, exchangeName, queueName);
                }
            }
        }
    }
}