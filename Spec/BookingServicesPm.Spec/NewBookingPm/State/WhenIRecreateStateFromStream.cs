using System;
using System.Collections.Generic;
using Core.Booking.Payment;
using Core.Booking.TheRoom;
using Core.BookingProcess;
using Core.Markers;
using NUnit.Framework;
using ProcessManagement.Processes.State;

namespace BookingServicesPm.Spec.NewBookingPm.State
{
    [TestFixture]
    public class WhenIRecreateStateFromStreamOf3Events:Specification
    {
        private NewBookingProcessState state;

        private Guid id;

        private NewReservation newReservation;
        private RoomPriced roomPriced;
        private CardCharged cardCharged;

        private List<IEvent> events;

        protected override void Given()
        {
            id = Guid.NewGuid();

            newReservation = new NewReservation()
                {
                    Id = id,
                    CheckIn = DateTime.Now.Date,
                    CheckOut = DateTime.Now.Date.AddDays(3),
                    PaymentInfo = new PaymentInfo(){Id = id},
                    RoomType = RoomType.Queen
                };

            roomPriced = new RoomPriced() { Id = id, PaymentAmount = new PaymentAmount() { Id = id, Amount = 55.32 } };

            cardCharged = new CardCharged(){Id = id};
            
            events = new List<IEvent>(){newReservation, roomPriced, cardCharged};
        }


        protected override void When()
        {
            state = new NewBookingProcessState(events);
        }

        [Test]
        public void It_should_set_state_id()
        {
            Assert.AreEqual(id, state.Id);
        }

        [Test]
        public void It_should_set_payment_info()
        {
            Assert.AreEqual(id, state.PaymentInfo.Id);
           
        }

        [Test]
        public void It_should_set_room_type()
        {
            Assert.AreEqual(RoomType.Queen, state.RoomType);
        }

        [Test]
        public void It_should_set_check_inout_dates()
        {
            Assert.AreEqual(DateTime.Now.Date, state.CheckIn);
            Assert.AreEqual(DateTime.Now.Date.AddDays(3), state.CheckOut);
        }

        [Test]
        public void It_should_set_amount()
        {
            Assert.AreEqual(id, state.PaymentAmount.Id);
            Assert.AreEqual(55.32, state.PaymentAmount.Amount);
        }
    }
}