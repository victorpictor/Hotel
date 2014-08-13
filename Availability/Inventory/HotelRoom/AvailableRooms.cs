using System;
using System.Collections.Generic;

namespace Inventory.HotelRoom
{
    public class AvailableRooms
    {
        public Guid Id = Guid.NewGuid();

        public List<RoomPrice> RoomPrices;
    }
}