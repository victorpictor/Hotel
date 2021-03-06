﻿using System;
using System.Collections.Generic;
using Core.Booking.TheRoom;
using Inventory.HotelRoom;

namespace Inventory.Services.Repositories
{
    public interface IRoomPriceRepository
    {
        List<RoomPrice> Get(RoomType type, DateTime start, DateTime end);
    }
}