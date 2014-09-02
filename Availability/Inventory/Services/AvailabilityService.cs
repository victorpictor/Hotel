using System;
using System.Linq;
using Inventory.HotelRoom;

namespace Inventory.Services
{
    public class AvailabilityService
    {
        private IInventoryService inventoryService;
        private IRoomPriceService roomPriceService;

        public AvailabilityService(IInventoryService inventoryService, IRoomPriceService roomPriceService)
        {
            this.inventoryService = inventoryService;
            this.roomPriceService = roomPriceService;
        }

        public AvailableRooms Get(DateTime from, DateTime to)
        {
            var availableRoomTypes = inventoryService.AllRooms(from, to);

            var offer = availableRoomTypes.Select(art => roomPriceService.Calculate(art, from, to));

            return new AvailableRooms(){RoomPrices = offer.ToList()};
        }
    }
}