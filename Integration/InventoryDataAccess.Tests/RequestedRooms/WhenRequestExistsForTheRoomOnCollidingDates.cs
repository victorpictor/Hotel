using System;
using Inventory.HotelRoom;
using InventoryDataAccess.Repositories;
using NUnit.Framework;

namespace InventoryDataAccess.Tests.RequestedRooms
{
    [TestFixture]
    public class WhenRequestExistsForTheRoomOnCollidingDates : HasMongoSetUp
    {
        private BookRoomRequests bookRoomRequests;
        private int roomId = 10;

        private bool result;

        public override void Given()
        {
            var requests = database.GetCollection("BookRoomRequests");
            requests.Save(new SubmittedBookRoomRequest(){RoomId = roomId, StartDate = DateTime.Now.AddDays(-3).Date, EndDate = DateTime.Now.AddDays(2).Date});

            bookRoomRequests = new BookRoomRequests();
        }


        public override void When()
        {
            result = bookRoomRequests.Exists(roomId, DateTime.Now.AddDays(-5), DateTime.Now);
        }

        [Test]
        public void It_should_return_true_as_an_existing_booking_request_on_given_dates()
        {
            Assert.AreEqual(true,result,"Expected the room to be unavailable");
        }
    }
}