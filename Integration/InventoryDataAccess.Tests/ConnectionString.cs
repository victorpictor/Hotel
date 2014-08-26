using System.Configuration;

namespace InventoryDataAccess.Tests
{
    public class ConnectionString
    {
        public string MongoUrl = ConfigurationManager.ConnectionStrings["MongoUrl"].ConnectionString;
    }
}