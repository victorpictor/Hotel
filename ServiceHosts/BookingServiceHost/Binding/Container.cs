using System.Collections.Generic;
using System.Threading;
using Core.Sender;
using Core.Store;
using EventsStore.StreamReader;
using MessageTransport.Publisher;
using MessageTransport.Sender;
using ProcessManagement.Processes;

namespace BookingServiceHost.Binding
{
    public class Container
    {
        public static IEventPublisher GetPublisher()
        {
            return new EventPublisher();
        }

        public static ICommandSerder GetSender()
        {
            return new MessageSender();
        }

        public static IEventStore GetEventStore()
        {
            return new EventStore();
        }

        public static NewBookingProcess GetNewBookingProcess()
        {
            return new NewBookingProcess(GetEventStore(), GetSender(), GetPublisher());
        }
    }
}