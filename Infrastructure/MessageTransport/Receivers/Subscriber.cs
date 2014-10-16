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

        public Subscriber(dynamic o, List<IReceiveMessage<Type>> handlers)
        {
            this.messageType = o.GetType();
            this.handlers = handlers;
        }

        public void Start()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclarePassive(messageType.Name);

                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume(messageType.Name, true, consumer);
                      
                        while (true)
                        {
                            var eventArgs = consumer.Queue.Dequeue();

                            var body = eventArgs.Body;
                            var messageJson = Encoding.UTF8.GetString(body);
                           
                            dynamic message = JsonConvert.DeserializeObject(messageJson, messageType);
                           
                            handlers.ForEach(h => h.Receive(message));
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