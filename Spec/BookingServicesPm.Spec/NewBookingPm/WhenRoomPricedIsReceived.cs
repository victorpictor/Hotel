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
    public class WhenRoomPricedIsReceived: Specification
    {
        private MyNewBookingProcess newBookingProcess;
        private InMemoryEventStore events;
        private InMemoryMessageSender sender;
        private InMemoryMessagePublisher publisher;
        private Guid processId;

        protected override void Given()
        {
            processId = Guid.NewGuid();

            events = new InMemoryEventStore();
            events.EventStore = new List<IEvent>() {};

            sender = new InMemoryMessageSender();
            publisher = new InMemoryMessagePublisher();

            newBookingProcess = new MyNewBookingProcess(events, sender, publisher);
        }

        protected override void When()
        {
            newBookingProcess.Receive(new RoomPriced() { Id = processId, PaymentAmount = new PaymentAmount() { Id = processId, Amount = 43.00 } });
        }

        [Test]
        public void It_should_apply_RoomPriced()
        {
            Assert.AreEqual(true, newBookingProcess.State().RoomPriced);
            Assert.AreEqual(43.00, newBookingProcess.State().PaymentAmount.Amount);
        }

        [Test]
        public void It_should_not_any_send_ChangeCard_message()
        {
            Assert.IsFalse(sender.Sent.Any());
        } 
    }
}