using System.Configuration;

namespace EventsStore.Tests
{
    public class ConnectionString
    {
        public string MongoUrl = ConfigurationManager.ConnectionStrings["MongoUrl"].ConnectionString; 
    }
}