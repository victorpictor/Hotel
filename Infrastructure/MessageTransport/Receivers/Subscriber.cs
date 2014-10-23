using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MessageTransport.Receivers
{
    public class Subscriber<T>
    {
        private readonly Type messageType;
        private readonly T receiver;


        public Subscriber(T receiver)
        {
            if (GetType().IsGenericType)
            {
                this.messageType = GetType()
                        .GetGenericArguments()[0]
                        .GetGenericArguments()[0];
            }


            this.receiver = receiver;
        }


        public void Start()
        {
            Task.Factory.StartNew(Run);
        }

        public void Run()
        {
            try
            {
                var factory = new ConnectionFactory() {HostName = Config.Host};
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

                            ((dynamic) receiver).Receive(message);
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