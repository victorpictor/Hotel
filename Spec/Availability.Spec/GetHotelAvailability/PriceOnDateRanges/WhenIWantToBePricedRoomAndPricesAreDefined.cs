using System;
using System.Collections.Generic;
using Core.Booking.TheRoom;
using Inventory.HotelRoom;
using Inventory.Services;
using Inventory.Services.Repositories;
using Moq;
using NUnit.Framework;

namespace Availability.Spec.GetHotelAvailability.PriceOnDateRanges
{
    [TestFixture]
    public class WhenIWantToBePricedRoomAndPricesAreDefined:Specification
    {

        private RoomPriceService roomPriceService;
        private Mock<IRoomPriceRepository> prices;

        private DateTime checkIn;
        private DateTime checkOut;

        private RoomPrice roomPrice;

        protected override void Given()
        {
            checkIn = DateTime.Now.AddDays(1);
            checkOut = DateTime.Now.AddDays(5);

            prices = new Mock<IRoomPriceRepository>();

            prices.Setup(r => r.Get(RoomType.King, checkIn, checkOut))
                  .Returns(new List<RoomPrice>() {new RoomPrice() {PerNight = 81}, new RoomPrice() {PerNight = 83}});

            roomPriceService = new RoomPriceService(prices.Object);
        }


        protected override void When()
        {
            roomPrice = roomPriceService.Calculate(RoomType.King, checkIn, checkOut);
        }

        [Test]
        public void It_should_get_prices_for_given_dates()
        {
            prices.Verify(v => v.Get(RoomType.King, checkIn,checkOut));
        }

        [Test]
        public void It_should_return_avg_price_per_night()
        {
            Assert.AreEqual(82,roomPrice.PerNight, "Calculated price doesn't match expectation of 82");
        }
    }
}