using MongoDB.Driver;

namespace InventoryDataAccess.Tests
{
    public class HasMongoSetUp
    {
        private string dbName;

        protected MongoDatabase database;

        public HasMongoSetUp(string dbName)
        {
            this.dbName = dbName;

            var client = new MongoClient(new ConnectionString().MongoUrl);
            var server = client.GetServer();

            database = server.GetDatabase(dbName); 
        }

        ~HasMongoSetUp()
        {
            database.Drop();
        }
    }
}
