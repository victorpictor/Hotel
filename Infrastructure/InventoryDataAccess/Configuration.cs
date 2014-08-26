using System;
using System.Configuration;

namespace InventoryDataAccess
{
    public class Configuration
    {
        public string MongoDbName = ConfigurationManager.AppSettings["AvailabilityStorage"];
        
        public string MongoUrl = ConfigurationManager.ConnectionStrings["MongoUrl"].ConnectionString;
    }
}