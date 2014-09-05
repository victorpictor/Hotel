using System.Collections.Generic;
using System.Linq;
using Core.TheRoom;
using Inventory.HotelRoom;
using NUnit.Framework;
using Room = Inventory.HotelRoom.Room;

namespace InventoryDataAccess.Tests.Rooms
{
    [TestFixture]
    public class WhenIRequestRoomByType: HasMongoSetUp
    {
        public List<Room> kingRooms;

        public override void Given()
        {
            var rooms = database.GetCollection("Rooms");

            rooms.Save(new Room {Id = 1, Type = RoomType.King, BookedOn = new List<BookedOnRange>()});
            rooms.Save(new Room {Id = 2, Type = RoomType.Queen, BookedOn = new List<BookedOnRange>()});
        }


        public override void When()
        {
            kingRooms = new Repositories.Rooms().Get(RoomType.King);
        }

        [Test]
        public void It_should_return_requested_room_type()
        {
            Assert.AreEqual(RoomType.King, kingRooms[0].Type, "It was expected to be returned one king room");
        }

        [Test]
        public void It_should_not_return_other_types()
        {
            Assert.IsFalse(kingRooms.Any(kr => kr.Type == RoomType.Queen),"It was expected to be found only king rooms");
        }

    }
}