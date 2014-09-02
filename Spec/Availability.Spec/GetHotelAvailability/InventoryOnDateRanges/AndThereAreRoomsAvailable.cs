using System;
using System.Collections.Generic;
using System.Linq;
using Inventory.HotelRoom;
using Inventory.Services;
using Inventory.Services.Repositories;
using Moq;
using NUnit.Framework;

namespace Availability.Spec.GetHotelAvailability.InventoryOnDateRanges
{
    [TestFixture]
    public class AndThereAreRoomsAvailable: Specification
    {

        private InventoryService inventoryService;

        private Mock<IBookRoomRequestsRepository> requests;
        private Mock<IRoomRepository> rooms;

        private List<RoomType> searchResult;

        protected override void Given()
        {
            requests = new Mock<IBookRoomRequestsRepository>();
            rooms = new Mock<IRoomRepository>();

            requests.Setup(r => r.Exists(2, DateTime.Now.Date.AddDays(3), DateTime.Now.Date.AddDays(6).Date)).Returns(true);

            rooms.Setup(r => r.Get(RoomType.Queen)).Returns(new List<Room>()
                     {
                        new Room()
                             {
                                 Id = 2,
                                 Type = RoomType.Queen,
                                 BookedOn =
                                     new List<BookedOnRange>()
                                         {
                                             new BookedOnRange(){CheckIn = DateTime.Now.AddDays(12).Date,CheckOut = DateTime.Now.AddDays(18).Date}
                                         }
                             },
                             new Room()
                             {
                                 Id = 3,
                                 Type = RoomType.Queen,
                                 BookedOn =
                                     new List<BookedOnRange>()
                                         {
                                             new BookedOnRange(){CheckIn = DateTime.Now.AddDays(1).Date,CheckOut = DateTime.Now.AddDays(7).Date}
                                         }
                             }
                     });

            rooms.Setup(r => r.Get(RoomType.King))
                 .Returns(new List<Room>()
                     {
                         new Room()
                             {
                                 Id = 1,
                                 Type = RoomType.King,
                                 BookedOn =
                                     new List<BookedOnRange>()
                                         {
                                             new BookedOnRange(){CheckIn = DateTime.Now.AddDays(16),CheckOut = DateTime.Now.AddDays(17)}
                                         }
                             }
                     });

            inventoryService = new InventoryService(requests.Object, rooms.Object);
        }

        protected override void When()
        {
            searchResult = inventoryService.AllRooms(DateTime.Now.Date.AddDays(3), DateTime.Now.Date.AddDays(6));
        }

        [Test]
        public void It_should_get_rooms_by_type()
        {
            rooms.Verify(r => r.Get(RoomType.King));
            rooms.Verify(r => r.Get(RoomType.Queen));
        }

        [Test]
        public void It_should_exculude_unavaialble_rooms_for_given_date_range()
        {
            Assert.AreEqual(1,searchResult.Count,"Should be available one room");
        }

        [Test]
        public void It_should_exculude_avaialble_rooms_for_given_date_range_but_with_a_hold_on_date_range()
        {
            Assert.AreEqual(RoomType.King, searchResult.FirstOrDefault(), "Should be available room #1");
        }

    }
}