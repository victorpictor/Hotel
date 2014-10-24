using System;
using System.Collections.Generic;
using Core.MessageReceiver;
using Core.Pricing;
using MessageTransport.Channels;
using MessageTransport.Receivers;
using MessageTransport.Sender;

namespace RoomPricingServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageExchanges = new List<MessageExchange>()
                {
                   new MessageExchange(typeof (GetRoomPrice).Name, "hotel.room.prices"),
                };

            new MessagingInfrastructure()
                .SetExchanges(messageExchanges)
                .SetMonitoring("hotel.process.monitoring");

            new MessageSender().Send(new GetRoomPrice() { Id = Guid.NewGuid() });

            new Subscriber<IReceiveMessage<GetRoomPrice>>(null).Start();
        }
    }
}
