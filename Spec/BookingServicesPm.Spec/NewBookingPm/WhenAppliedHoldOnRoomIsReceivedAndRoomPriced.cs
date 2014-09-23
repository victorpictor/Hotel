using System;
using System.Collections.Generic;
using Core.Booking.Payment;
using Core.BookingProcess;
using Core.Markers;
using Core.Payments;
using NUnit.Framework;

namespace BookingServicesPm.Spec.NewBookingPm
{
    [TestFixture]
    public class WhenAppliedHoldOnRoomIsReceivedAndRoomPriced: Specification
    {
        private MyNewBookingProcess newBookingProcess;
        private InMemoryEventStore events;
        private InMemoryMessageSender sender;
        private Guid processId;

        protected override void Given()
        {
            processId = Guid.NewGuid();

            events = new InMemoryEventStore();
            events.EventStore = new List<IEvent>() { new RoomPriced() { Id = processId, PaymentAmount = new PaymentAmount() { Id = processId, Amount = 43.00 } } };

            sender = new InMemoryMessageSender();

            newBookingProcess = new MyNewBookingProcess(events, sender);
        }

        protected override void When()
        {
            newBookingProcess.Receive(new AppliedHoldOnRoom { Id = processId });
        }

        [Test]
        public void It_should_apply_AppliedHoldOnRoom()
        {
            Assert.AreEqual(true, newBookingProcess.State().HoldingAvailability);
        }

        [Test]
        public void It_should_send_ChangeCard_message()
        {
            var command = (ChargeCard)sender.Sent[0];

            Assert.AreEqual(typeof(ChargeCard), command.GetType());
            Assert.AreEqual(command.Id, processId);
            Assert.AreEqual(43.00, command.PaymentAmount.Amount);
        }

    }
}