using System;
using System.Collections.Generic;
using Core.TheRoom;
using Inventory.HotelRoom;
using Inventory.Services.Repositories;

namespace InventoryDataAccess.Repositories
{
    public class RoomPrices : IRoomPriceRepository
    {
        public List<RoomPrice> Get(RoomType type, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}