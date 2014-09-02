using System;
using System.Collections.Generic;
using Inventory.HotelRoom;
using Inventory.Services;
using Inventory.Services.Exceptions;
using Inventory.Services.Repositories;
using Moq;
using NUnit.Framework;

namespace Availability.Spec.GetHotelAvailability.PriceOnDateRanges
{
    [TestFixture]
    public class WhenIWantToBePricedRoomAndNoPricesAreDefined: Specification
    {
        private RoomPriceService roomPriceService;
        private Mock<IRoomPriceRepository> prices;

        protected override void Given()
        {
            prices = new Mock<IRoomPriceRepository>();
            prices.SetReturnsDefault(new List<RoomPrice>());

            roomPriceService = new RoomPriceService(prices.Object);
        }

        [Test]
        [ExpectedException(typeof(CouldNotBePricedDateRange))]
        public void It_should_throw_could_not_price_date_range_exception()
        {
            roomPriceService.Calculate(RoomType.King, DateTime.Now, DateTime.Now.AddDays(1));
        }
    }
}