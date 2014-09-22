using System;
using System.Collections.Generic;
using System.Linq;
using Core.Booking.Payment;
using Core.BookingProcess;
using Core.Markers;
using NUnit.Framework;

namespace BookingServicesPm.Spec.NewBookingPm
{
    [TestFixture]
    public class WhenAppliedHoldOnRoomIsReceived : Specification
    {
        private MyNewBookingProcess newBookingProcess;
        private InMemoryEventStore events;
        private InMemoryMessageSender sender;
        private Guid processId;

        protected override void Given()
        {
            processId = Guid.NewGuid();

            events = new InMemoryEventStore();
            events.EventStore = new List<IEvent>() { };

            sender = new InMemoryMessageSender();

            newBookingProcess = new MyNewBookingProcess(events, sender);
        }

        protected override void When()
        {
            newBookingProcess.Receive(new AppliedHoldOnRoom() { Id = processId});
        }

        [Test]
        public void It_should_apply_AppliedHoldOnRoom()
        {
            Assert.AreEqual(true, newBookingProcess.State().HoldingAvailability);
        }

        [Test]
        public void It_should_not_any_send_ChangeCard_message()
        {
            Assert.IsFalse(sender.Sent.Any());
        } 
    }
}
