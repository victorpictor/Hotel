using System;
using System.Collections.Generic;
using System.Linq;
using Core.TheRoom;
using Inventory.HotelRoom;
using Inventory.Services;
using Moq;
using NUnit.Framework;

namespace Availability.Spec.GetHotelAvailability
{
    [TestFixture]
    public class WhenISpecifyDateRange: Specification
    {
        private Mock<IInventoryService> inventoryService;
        private Mock<IRoomPriceService> priceService;
        private Mock<IAvailabilitySessionService> availabilitySessionService;
        
        private DateTime checkIn;
        private DateTime checkOut;
        
        private AvailabilityService availabilityService;
        private AvailableRooms available;

        protected override void Given()
        {

            checkIn = DateTime.Now.AddDays(32);
            checkOut = DateTime.Now.AddDays(39);

            inventoryService = new Mock<IInventoryService>();
            inventoryService.Setup(i => i.AllRooms(checkIn, checkOut)).Returns(new List<RoomType>(){RoomType.King, RoomType.Queen});

            availabilitySessionService = new Mock<IAvailabilitySessionService>();

            priceService = new Mock<IRoomPriceService>();
            priceService.Setup(p => p.Calculate(RoomType.King, checkIn, checkOut)).Returns(new RoomPrice(RoomType.King, checkIn,checkOut, 44));
            priceService.Setup(p => p.Calculate(RoomType.Queen, checkIn, checkOut)).Returns(new RoomPrice(RoomType.Queen, checkIn, checkOut, 34));

            availabilityService = new AvailabilityService(inventoryService.Object, priceService.Object, availabilitySessionService.Object);
           
        }

        protected override void When()
        {
            available = availabilityService.Get(checkIn, checkOut);
        }

        [Test]
        public void It_should_get_available_room_types()
        {
            inventoryService.Verify(r => r.AllRooms(checkIn,checkOut));
        }

        [Test]
        public void It_should_price_each_room_type()
        {
            priceService.Verify(p => p.Calculate(RoomType.King, checkIn, checkOut));
            priceService.Verify(p => p.Calculate(RoomType.Queen, checkIn, checkOut));
        }

        [Test]
        public void It_should_return_2_available_rooms()
        {
            Assert.AreEqual(available.AvailableRoomsCount(),2,"It were expected 2 rooms available");
        }

        [Test]
        public void It_should_store_response_in_session()
        {
            availabilitySessionService.Verify(ass => ass.Store(available));
        }

        [Test]
        public void It_should_return_king_room_for_44()
        {
            var kingRoom = available.RoomPrices.Where(rp => rp.RoomType == RoomType.King).First();
            Assert.AreEqual(kingRoom.PerNight, 44, "It was expected king room to be 44");
        }

        [Test]
        public void It_should_return_queen_room_for_34()
        {
            var queenRoom = available.RoomPrices.Where(rp => rp.RoomType == RoomType.Queen).First();

            Assert.AreEqual(queenRoom.PerNight, 34, "It was expected queen room to be 34");
        }

    }
}