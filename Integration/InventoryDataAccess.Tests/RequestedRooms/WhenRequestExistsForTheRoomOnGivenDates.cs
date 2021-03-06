﻿using System;
using Inventory.HotelRoom;
using InventoryDataAccess.Repositories;
using NUnit.Framework;

namespace InventoryDataAccess.Tests.RequestedRooms
{
    [TestFixture]
    public class WhenRequestExistsForTheRoomOnGivenDates : HasMongoSetUp
    {
        private BookRoomRequests bookRoomRequests;
        private int roomId = 10;

        private bool result;

        public override void Given()
        {
            var requests = database.GetCollection("BookRoomRequests");
            requests.Save(new SubmittedBookRoomRequest() { RoomId = roomId, StartDate = DateTime.Now.AddDays(-3), EndDate = DateTime.Now.AddDays(2) });

            bookRoomRequests = new BookRoomRequests();
        }


        public override void When()
        {
            result = bookRoomRequests.Exists(roomId, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(2));
        }

        [Test]
        public void It_should_return_true_as_an_existing_booking_request_on_given_dates()
        {
            Assert.AreEqual(true, result, "Expected the room to be unavailable");
        }
    }
}