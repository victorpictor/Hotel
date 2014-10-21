using System;
using System.Text;
using MessageTransport.Channels;
using NUnit.Framework;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MessageTransport.Tests.Senders
{
    [TestFixture]
    public class WhenIPublishMessage : Specification
    {
        private MessageExchange messageExchange;
        
        private string message;

        public override void Given()
        {
            messageExchange = new MessageExchange("test","exchangeName");

            var factory = new ConnectionFactory() { HostName = Config.Host };
            
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(messageExchange.ExchangeName, Channels.ExchangeType.Fanout, true, false, null);

                    channel.QueueDeclare(messageExchange.MessageName, true, false, false, null);
                    channel.QueueBind(messageExchange.MessageName, messageExchange.ExchangeName, string.Empty);
                }
            }
        }

        public override void When()
        {
            new ChannelPublisher().Publish("Test-2",messageExchange);

            try
            {
                var factory = new ConnectionFactory() { HostName = Config.Host };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {

                        channel.QueueDeclarePassive(messageExchange.MessageName);

                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume(messageExchange.MessageName, true, consumer);

                        while (true)
                        {
                            var eventArgs = consumer.Queue.Dequeue();
                            var body = eventArgs.Body;
                            message = Encoding.UTF8.GetString(body);
                            message = (string)JsonConvert.DeserializeObject(message, typeof(string));

                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        [Test]
        public void It_should_receive_published_message()
        {
            Assert.AreEqual("Test-2", message);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            var factory = new ConnectionFactory() { HostName = Config.Host };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDelete(messageExchange.ExchangeName);
                    channel.QueueDelete(messageExchange.MessageName);
                }
            }
        }

    }
}