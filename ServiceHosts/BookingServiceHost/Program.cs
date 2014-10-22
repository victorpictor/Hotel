using System;
using System.Collections.Generic;
using Core.Availability;
using Core.BookingProcess;
using MessageTransport.Channels;
using MessageTransport.Receivers;
using MessageTransport.Sender;
using Messages.Availability;

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

            new MessageSender(messageExchanges).Send(new ApplyHoldOnRoomAvailability() { Id = Guid.NewGuid() });
            new MessageSender(messageExchanges).Send(new MarkRoomBooked() { Id = Guid.NewGuid() });

            new Subscriber(new ApplyHoldOnRoomAvailability(), null).Start();
            new Subscriber(new MarkRoomBooked(), null).Start();
        }
    }
}
