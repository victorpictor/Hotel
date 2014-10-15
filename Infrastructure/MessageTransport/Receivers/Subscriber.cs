using System;
using System.Collections.Generic;
using System.Text;
using Core.MessageReceiver;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MessageTransport.Receivers
{
    public class Subscriber
    {
        private readonly Type messageType;
        private readonly List<IReceiveMessage<Type>> handlers;

        public Subscriber(object o, List<IReceiveMessage<Type>> handlers)
        {
            this.messageType = o.GetType();
            this.handlers = handlers;
        }

        public void Start()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "config.localhost" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(messageType.Name, true, false, false, null);

                        channel.BasicQos(0, 1, false);
                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume(messageType.Name, false, consumer);

                        while (true)
                        {
                            var ea = consumer.Queue.Dequeue();

                            var body = ea.Body;
                            
                            var messageJson = Encoding.UTF8.GetString(body);

                            dynamic message = JsonConvert.DeserializeObject(messageJson, messageType);

                            handlers.ForEach(r => r.Receive(message));

                            channel.BasicAck(ea.DeliveryTag, false);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

          
        }
    }
}