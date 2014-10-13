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
    public class WhenRoomPricedIsReceivedAndHoldingAvailability: Specification
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
            events.EventStore = new List<IEvent>(){new AppliedHoldOnRoom{Id = processId}};

            sender = new InMemoryMessageSender();
            publisher = new InMemoryMessagePublisher();

            newBookingProcess = new MyNewBookingProcess(events, sender, publisher);
        }

        protected override void When()
        {
            newBookingProcess.Receive(new RoomPriced(){Id = processId, PaymentAmount = new PaymentAmount(){Id = processId, Amount = 43.00}});
        }

        [Test]
        public void It_should_apply_RoomPriced()
        {
            Assert.AreEqual(true, newBookingProcess.State().RoomPriced);
            Assert.AreEqual(43.00, newBookingProcess.State().PaymentAmount.Amount);
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