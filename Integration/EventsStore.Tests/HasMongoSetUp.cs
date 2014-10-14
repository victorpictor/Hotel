using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;

namespace EventsStore.Tests
{
    public class HasMongoSetUp : Specification
    {
        static HasMongoSetUp()
        {
            DateTimeSerializationOptions.Defaults = new DateTimeSerializationOptions(DateTimeKind.Local, BsonType.Document);
        }

        protected MongoDatabase database;

        public HasMongoSetUp()
        {
            var client = new MongoClient(new ConnectionString().MongoUrl);
            var server = client.GetServer();

            database = server.GetDatabase(new Configuration().MongoDbName);
        }

        ~HasMongoSetUp()
        {
            database.Drop();
        }
    }
}
