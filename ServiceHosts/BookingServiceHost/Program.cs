using MessageTransport.Channels;

namespace BookingServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            new ExchangeSetup("test",ExchangeType.Fanout);

            new QueuesSetup("test", "myQueue");
        }
    }
}
