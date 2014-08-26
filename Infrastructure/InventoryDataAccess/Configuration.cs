using System.Configuration;

namespace InventoryDataAccess
{
    public class Configuration
    {
        public string MongoDbName = "HotelAvailability";


        public string MongoUrl = ConfigurationManager.ConnectionStrings["MongoUrl"].ConnectionString;
    }
}