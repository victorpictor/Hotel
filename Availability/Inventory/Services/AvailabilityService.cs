using System;
using System.Linq;
using Inventory.HotelRoom;

namespace Inventory.Services
{
    public class AvailabilityService
    {
        private IInventoryService inventoryService;
        private IRoomPriceService roomPriceService;
        private IAvailabilitySessionService availabilitySessionService;

        public AvailabilityService(IInventoryService inventoryService, IRoomPriceService roomPriceService, IAvailabilitySessionService availabilitySessionService)
        {
            this.inventoryService = inventoryService;
            this.roomPriceService = roomPriceService;
            this.availabilitySessionService = availabilitySessionService;
        }

        public AvailableRooms Get(DateTime from, DateTime to)
        {
            var availableRoomTypes = inventoryService.AllRooms(from, to);

            var offer = availableRoomTypes.Select(art => roomPriceService.Calculate(art, from, to));

            var availableRooms = new AvailableRooms(){RoomPrices = offer.ToList()};

            availabilitySessionService.Store(availableRooms);

            return availableRooms;
        }
    }
}