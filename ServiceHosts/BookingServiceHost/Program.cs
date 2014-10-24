using System;
using System.Collections.Generic;
using BookingServiceHost.Binding;
using Core.Availability;
using Core.BookingProcess;
using Core.MessageReceiver;
using MessageTransport.Channels;
using MessageTransport.Publisher;
using MessageTransport.Receivers;
using ProcessManagement.Processes;

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

            //concurrency problem  
            new Subscriber<IReceiveMessage<NewReservation>>(Container.GetNewBookingProcess()).Start();
            new Subscriber<IReceiveMessage<RoomPriced>>(Container.GetNewBookingProcess()).Start();
            new Subscriber<IReceiveMessage<AppliedHoldOnRoom>>(Container.GetNewBookingProcess()).Start();
            new Subscriber<IReceiveMessage<NoRoomsAvailable>>(Container.GetNewBookingProcess()).Start();
            new Subscriber<IReceiveMessage<CardCharged>>(Container.GetNewBookingProcess()).Start();
            new Subscriber<IReceiveMessage<ChargeCardFailed>>(Container.GetNewBookingProcess()).Start();
        }
    }
}
