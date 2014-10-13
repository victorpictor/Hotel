using System;
using Core.Booking.Payment;
using Core.Booking.TheRoom;
using Core.BookingProcess;
using Core.Pricing;
using Messages.Availability;
using NUnit.Framework;

namespace BookingServicesPm.Spec.NewBookingPm
{
    [TestFixture]
    public class WhenNewReservationIsReceived: Specification
    {

        private MyNewBookingProcess newBookingProcess;
        private InMemoryEventStore events;
        private InMemoryMessageSender sender;
        private InMemoryMessagePublisher publisher;
        private Guid processId;
        private DateTime checkIn;
        private DateTime checkOut;

        protected override void Given()
        {
            processId = Guid.NewGuid();
            checkIn = DateTime.Now.Date;
            checkOut = DateTime.Now.Date.AddDays(4);

            events = new InMemoryEventStore();
            sender = new InMemoryMessageSender();
            publisher = new InMemoryMessagePublisher();

            newBookingProcess = new MyNewBookingProcess(events, sender, publisher);
        }

        protected override void When()
        {
            newBookingProcess.Receive(new NewReservation()
                {
                    Id = processId,
                    RoomType = RoomType.Queen,
                    PaymentInfo = new PaymentInfo() {Id = processId},
                    CheckIn = checkIn,
                    CheckOut = checkOut
                });
        }

        [Test]
        public void It_should_apply_NewReservation_message_on_process_manager_state()
        {
            Assert.AreEqual(newBookingProcess.State().Id,processId);
        }

        [Test]
        public void It_should_append_to_stream_NewReservation_event()
        {
            var message = events.EventStore[0];

            Assert.AreEqual(typeof(NewReservation), message.GetType());
            Assert.AreEqual(message.Id, processId);
        }

        [Test]
        public void It_should_send_ApplyHoldOnRoomAvailability()
        {
            var message = sender.Sent[0];

            Assert.AreEqual(typeof(ApplyHoldOnRoomAvailability),message.GetType());
            Assert.AreEqual(message.Id, processId);
        }

        [Test]
        public void It_should_send_GetRoomPrice()
        {
            var message = sender.Sent[1];

            Assert.AreEqual(typeof(GetRoomPrice), message.GetType());
            Assert.AreEqual(message.Id, processId);
        }
    }
}