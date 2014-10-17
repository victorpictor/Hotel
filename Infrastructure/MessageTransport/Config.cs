using System.Configuration;

namespace MessageTransport
{
    public static class Config
    {
        public static readonly string Host = ConfigurationManager.AppSettings["HostName"];
    }
}