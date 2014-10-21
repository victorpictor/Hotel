using System;
using System.Collections.Generic;
using Core.Availability;
using Core.BookingProcess;
using Core.Pricing;
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
                    new MessageExchange(typeof (NewReservation).Name, "new.booking.process"),
                    new MessageExchange(typeof (RoomPriced).Name, "new.booking.process"),
                    new MessageExchange(typeof (AppliedHoldOnRoom).Name, "new.booking.process"),
                    new MessageExchange(typeof (NoRoomsAvailable).Name, "new.booking.process"),
                    new MessageExchange(typeof (CardCharged).Name, "new.booking.process"),
                    new MessageExchange(typeof (ChargeCardFailed).Name, "new.booking.process"),
                    
                    new MessageExchange(typeof (GetRoomPrice).Name, "room.prices"),
                    
                    new MessageExchange(typeof (ApplyHoldOnRoomAvailability).Name, "room.availability"),
                    new MessageExchange(typeof (MarkRoomBooked).Name, "room.availability"),
                };

            new MessagingInfrastructure()
                .SetExchanges(messageExchanges)
                .SetMonitoring("process.monitoring");

            new MessageSender(messageExchanges).Send(new ApplyHoldOnRoomAvailability() { Id = Guid.NewGuid() });
            new MessageSender(messageExchanges).Send(new MarkRoomBooked() { Id = Guid.NewGuid() });

            new Subscriber(new ApplyHoldOnRoomAvailability(), null).Start();
            new Subscriber(new MarkRoomBooked(), null).Start();
        }
    }
}
