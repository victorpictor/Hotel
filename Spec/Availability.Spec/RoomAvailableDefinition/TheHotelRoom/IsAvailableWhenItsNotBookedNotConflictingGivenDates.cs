using System;
using System.Collections.Generic;
using Inventory.Management;
using NUnit.Framework;

namespace Availability.Spec.RoomAvailableDefinition.TheHotelRoom
{
    [TestFixture]
    public class IsAvailableWhenBookedOnItsNotConflictingGivenDates:Specification
    {
        private Room room;

        private bool conflict;
        private bool booked;
        private bool available;

        protected override void Given()
        {
            room = new Room(){BookedOn = new List<BookedOnRange>(){new BookedOnRange(){CheckIn = DateTime.Now.AddDays(-1).Date, CheckOut = DateTime.Now.AddDays(4).Date}}};
        }


        protected override void When()
        {
            conflict = !room.IsAvailable(DateTime.Now.AddDays(-10).Date, DateTime.Now.AddDays(2).Date);
            booked = !room.IsAvailable(DateTime.Now.AddDays(-1).Date, DateTime.Now.AddDays(4).Date);
            available = room.IsAvailable(DateTime.Now.AddDays(-10).Date, DateTime.Now.AddDays(-4).Date);
        }

        [Test]
        public void It_should_be_conflicting_when_checking_in_or_out_when_already_booked()
        {
            Assert.AreEqual(true,conflict);
        }
        
        [Test]
        public void It_should_be_alredy_booked_when_same_dates()
        {
            Assert.AreEqual(true,booked);
        }

        [Test]
        public void It_should_be_available_when_no_entries_for_given_dates()
        {
            Assert.AreEqual(true, available);
        }

    }
}