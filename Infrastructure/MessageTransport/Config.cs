using System.Configuration;

namespace MessageTransport
{
    public static class Config
    {
        //public static readonly string Host = ConfigurationManager.AppSettings["HostName"];
        public static readonly string Host = "localhost";
        public static string MongoUrl = ConfigurationManager.ConnectionStrings["MongoUrl"].ConnectionString;

        public static string SubscriptionStorageName = "SubscriptionStorage";
    }
}