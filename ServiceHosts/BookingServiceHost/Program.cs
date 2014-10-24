using System;
using System.Collections.Generic;
using Core.Availability;
using Core.BookingProcess;
using Core.MessageReceiver;
using MessageTransport.Channels;
using MessageTransport.Publisher;
using MessageTransport.Receivers;

namespace BookingServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {

            var messageExchanges = new List<MessageExchange>()
                {
                    new MessageExchange(typeof (NewReservation).Name, "hotel.new.booking.process"),
                    new MessageExchange(typeof (RoomPriced).Name, "hotel.new.booking.process"),
                    new MessageExchange(typeof (AppliedHoldOnRoom).Name, "hotel.new.booking.process"),
                    new MessageExchange(typeof (NoRoomsAvailable).Name, "hotel.new.booking.process"),
                    new MessageExchange(typeof (CardCharged).Name, "hotel.new.booking.process"),
                    new MessageExchange(typeof (ChargeCardFailed).Name, "hotel.new.booking.process")
                };

            new MessagingInfrastructure()
                .SetExchanges(messageExchanges)
                .SetMonitoring("hotel.process.monitoring");

            new EventPublisher().Publish(new RoomPriced() { Id = Guid.NewGuid() });
            
            new Subscriber<IReceiveMessage<RoomPriced>>(null).Start();
        }
    }
}
