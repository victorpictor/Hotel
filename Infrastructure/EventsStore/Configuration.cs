using System.Configuration;

namespace EventsStore
{
    public class Configuration
    {
        public string MongoDbName = ConfigurationManager.AppSettings["EventsStorage"];

        public string MongoUrl = ConfigurationManager.ConnectionStrings["MongoUrl"].ConnectionString;
    }
}