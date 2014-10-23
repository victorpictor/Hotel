using System;
using System.Collections.Generic;
using Core.Availability;
using Core.MessageReceiver;
using MessageTransport.Channels;
using MessageTransport.Receivers;
using MessageTransport.Sender;
using Messages.Availability;
using RoomAvailabilityServiceHost.Binding;

namespace RoomAvailabilityServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageExchanges = new List<MessageExchange>()
                {
                   new MessageExchange(typeof (ApplyHoldOnRoomAvailability).Name, "hotel.room.availability"),
                   new MessageExchange(typeof (MarkRoomBooked).Name, "hotel.room.availability"),
                };

            new MessagingInfrastructure()
                .SetExchanges(messageExchanges)
                .SetMonitoring("hotel.process.monitoring");

            new MessageSender(messageExchanges).Send(new ApplyHoldOnRoomAvailability() { Id = Guid.NewGuid() });
            new MessageSender(messageExchanges).Send(new MarkRoomBooked() { Id = Guid.NewGuid() });

            
            new Subscriber<IReceiveMessage<ApplyHoldOnRoomAvailability>>(Container.GetInventoryHandler()).Start();

            new Subscriber<IReceiveMessage<MarkRoomBooked>>(Container.GetInventoryHandler()).Start();
        }
    }
}
