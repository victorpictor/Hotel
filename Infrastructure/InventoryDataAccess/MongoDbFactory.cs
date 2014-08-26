using MongoDB.Driver;

namespace InventoryDataAccess
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