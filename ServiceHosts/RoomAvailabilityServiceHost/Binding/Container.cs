using System.Collections.Generic;
using Core.Sender;
using Inventory.MessageHandlers;
using InventoryDataAccess.Repositories;
using MessageTransport.Channels;
using MessageTransport.Publisher;

namespace RoomAvailabilityServiceHost.Binding
{
    public class Container
    {
        private static List<MessageExchange> exchanges;

        public static void Init(List<MessageExchange> exch)
        {
            exchanges = exch;
        }

        public static IEventPublisher GetPublisher()
        {
            return new EventPublisher(exchanges);
        }

        public static InventoryHandler GetInventoryHandler()
        {
            return new InventoryHandler(GetPublisher(), null, new BookRoomRequests(), new RoomBookings() );
        }
    }
}