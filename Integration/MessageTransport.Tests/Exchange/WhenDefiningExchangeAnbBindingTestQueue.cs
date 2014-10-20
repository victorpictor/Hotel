using System;
using System.Text;
using MessageTransport.Channels;
using NUnit.Framework;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace MessageTransport.Tests.Exchange
{
    [TestFixture]
    public class WhenDefiningExchangeAnbBindingTestQueue : Specification
    {
        private MessageExchange messageExchange;
        private ExchangeSetup exchangeSetup;

        private string message;

        public override void Given()
        {
            messageExchange = new MessageExchange("testqueue","testexchange");

            exchangeSetup = new ExchangeSetup(messageExchange.ExchangeName, Channels.ExchangeType.Fanout);

            var factory = new ConnectionFactory() { HostName = Config.Host };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(messageExchange.MessageName,true,false,false,null);

                    channel.QueueBind(messageExchange.MessageName, messageExchange.ExchangeName, string.Empty);

                    var messageSerialized = JsonConvert.SerializeObject("Test");

                    var body = Encoding.UTF8.GetBytes(messageSerialized);

                    channel.BasicPublish(messageExchange.ExchangeName, "", null, body);
                }
            }

        }


        public override void When()
        {
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
        public void It_should_receive_the_message()
        {
            Assert.AreEqual("Test", message);
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