using System;
using Inventory.HotelRoom;
using Inventory.Services;
using Inventory.Services.Exceptions;
using NUnit.Framework;

namespace Availability.Spec.GetHotelAvailability.PriceOnDateRanges
{
    [TestFixture]
    public class WhenIWantToBePricedRoomAndDateRangeIsInvalid: Specification
    {
        private RoomPriceService roomPriceService;

        protected override void Given()
        {
           roomPriceService = new RoomPriceService(null);
        }

        [Test]
        [ExpectedException(typeof(InvalidDateRange))]
        public void It_should_throw_invalid_date_range_exception()
        {
            roomPriceService.Calculate(RoomType.King, DateTime.Now, DateTime.Now.AddDays(-1));
        }
    }
}