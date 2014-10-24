using System;
using System.Collections.Generic;
using Core.Availability;
using Core.Booking.TheRoom;
using Core.BookingProcess;
using Core.MessageReceiver;
using MessageTransport.Channels;
using MessageTransport.Publisher;
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

            new EventPublisher().Publish(new NewReservation() { Id = Guid.NewGuid(), CheckIn = DateTime.Now.AddDays(10), CheckOut = DateTime.Now.AddDays(15), RoomType = RoomType.Queen});
            
            new Subscriber<IReceiveMessage<ApplyHoldOnRoomAvailability>>(Container.GetInventoryHandler()).Start();
            new Subscriber<IReceiveMessage<MarkRoomBooked>>(Container.GetInventoryHandler()).Start();
        }
    }
}
