using System.Collections.Generic;
using System.Linq;
using MessageTransport.Channels;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MessageTransport.Subscriptions
{
    public class SubscriptionStorage
    {
        public MongoCollection<MessageExchange> GetCollection()
        {
            var client = new MongoClient(Config.MongoUrl);
            var server = client.GetServer();

            var database = server.GetDatabase(Config.SubscriptionStorageName);

            return  database.GetCollection<MessageExchange>("Subscriptions");
        }

        public void Store(MessageExchange xch)
        {
            var xchs = GetCollection(); 

            var existing = xchs.AsQueryable().Where(r => r.ExchangeName == xch.ExchangeName && r.MessageName == xch.ExchangeName).ToList();

            if (existing.Any())
                return;

            xchs.Save(xch);
        }

        public List<MessageExchange> AllMessageExchanges()
        {
            var xchs = GetCollection();

            return xchs.FindAll().ToList();
        }
    }
}