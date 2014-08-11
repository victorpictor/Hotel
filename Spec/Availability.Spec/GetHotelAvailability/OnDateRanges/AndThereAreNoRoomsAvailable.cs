using System;
using System.Collections.Generic;
using Inventory.Management;
using Inventory.Services;
using Inventory.Services.Repositories;
using Moq;
using NUnit.Framework;

namespace Availability.Spec.GetHotelAvailability.OnDateRanges
{
    [TestFixture]
    public class AndThereAreNoRoomsAvailable : Specification
    {
        private InventoryService inventoryService;

        private Mock<IBookRoomRequestsRepository> requests;
        private Mock<IRoomRepository> rooms;

        private List<int> searchResult;

        protected override void Given()
        {
            requests = new Mock<IBookRoomRequestsRepository>();
            rooms = new Mock<IRoomRepository>();

            rooms.Setup(r => r.Get(RoomType.All))
                 .Returns(new List<Room>()
                     {
                         new Room()
                             {
                                 Id = 1,
                                 BookedOn =
                                     new List<BookedOnRange>()
                                         {
                                             new BookedOnRange()
                                                 {
                                                     CheckIn = DateTime.Now.AddDays(1),
                                                     CheckOut = DateTime.Now.AddDays(16)
                                                 }
                                         }
                             }
                     });

            inventoryService = new InventoryService(requests.Object, rooms.Object);
        }

        protected override void When()
        {
            searchResult = inventoryService.AllRooms(DateTime.Now.AddDays(10), DateTime.Now.AddDays(15));
        }

        [Test]
        public void It_should_get_rooms_by_type()
        {
            rooms.Verify(r => r.Get(RoomType.All));
        }

        [Test]
        public void It_should_exclude_unavaialble_rooms_for_given_date_range()
        {
            Assert.AreEqual(0,searchResult.Count,"Rooms were found, when there're not");
        }

        [Test]
        public void It_should_not_check_for_applied_hold()
        {
            requests.Verify(r => r.Get(), Times.Never());
        }
        
    }
}