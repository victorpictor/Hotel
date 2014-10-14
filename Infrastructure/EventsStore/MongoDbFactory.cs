using MongoDB.Driver;

namespace EventsStore
{
    public class MongoDbFactory
    {
        protected MongoDatabase database;

        public MongoDatabase CreateDb(string dbName)
        {
            var client = new MongoClient(new Configuration().MongoUrl);
            var server = client.GetServer();

            database = server.GetDatabase(dbName);

            return database;
        } 
    }
}