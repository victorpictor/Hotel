using System;
using System.Collections.Generic;
using System.Linq;
using Core.Booking.TheRoom;
using Inventory.HotelRoom;
using InventoryDataAccess.Repositories;
using MongoDB.Driver.Linq;
using NUnit.Framework;
using Room = Inventory.HotelRoom.Room;

namespace InventoryDataAccess.Tests.Rooms
{
    [TestFixture]
    public class WhenIAddARoomBooking : HasMongoSetUp
    {
        private int roomId = 1;
        private DateTime checkIn;
        private DateTime checkOut;

        private RoomBookings roomBookings;
        private Room theRoom;


        public override void Given()
        {
            var rooms = database.GetCollection("Rooms");

            checkIn = DateTime.Now.Date.AddDays(4);
            checkOut = DateTime.Now.Date.AddDays(10);

            rooms.Save(new Room { Id = roomId, Type = RoomType.King, BookedOn = new List<BookedOnRange>()});

            roomBookings = new RoomBookings();
        }


        public override void When()
        {
            roomBookings.Add(roomId, checkIn, checkOut);

            theRoom = database.GetCollection<Room>("Rooms").AsQueryable().Where(r => r.Id == roomId).First();
        }

        [Test]
        public void It_should_not_be_available_anymore_on_given_dates()
        {
            Assert.IsFalse(theRoom.IsAvailable(checkIn,checkOut), "The room was expected to be unavailable");
        }
    }
}