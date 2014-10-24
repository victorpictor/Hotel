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
        public static IEventPublisher GetPublisher()
        {
            return new EventPublisher();
        }

        public static InventoryHandler GetInventoryHandler()
        {
            return new InventoryHandler(GetPublisher(), new SubmittedBookRoomRequests(), new BookRoomRequests(), new RoomBookings());
        }
    }
}