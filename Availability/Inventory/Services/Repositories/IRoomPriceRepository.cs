using System;
using System.Collections.Generic;
using Inventory.Management;
using Inventory.Pricing;

namespace Inventory.Services.Repositories
{
    public interface IRoomPriceRepository
    {
        List<RoomPrice> Get(RoomType type, DateTime start, DateTime end);
    }
}