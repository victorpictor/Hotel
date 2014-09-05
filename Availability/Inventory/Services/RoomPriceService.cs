using System;
using System.Linq;
using Core.TheRoom;
using Inventory.HotelRoom;
using Inventory.Services.Exceptions;
using Inventory.Services.Repositories;

namespace Inventory.Services
{
    public interface IRoomPriceService
    {
        RoomPrice Calculate(RoomType roomType, DateTime from, DateTime to);
    }

    public class RoomPriceService : IRoomPriceService
    {
        private IRoomPriceRepository roomPrices;

        public RoomPriceService(IRoomPriceRepository roomPrices)
        {
            this.roomPrices = roomPrices;
        }

        public RoomPrice Calculate(RoomType roomType, DateTime from, DateTime to)
        {
            if (from > to)
                throw new InvalidDateRange(string.Format("Invalid date rage for pricing [{0} {1}]", from, to));

            var rprices = roomPrices.Get(roomType, from, to);

            if (!rprices.Any())
                throw new CouldNotBePricedDateRange(string.Format("Date range could not be priced [{0} {1}]", from, to));

            return new RoomPrice(roomType, from, to, rprices.Average(p => p.PerNight));
            
        }
    }
}