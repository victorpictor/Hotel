using System;
using System.Collections.Generic;
using Core.Booking.Payment;
using Core.Booking.TheRoom;
using Core.BookingProcess;
using Core.Markers;

namespace ProcessManagement.Processes.State
{
    public class NewBookingProcessState
    {

        public Guid Id;

        public RoomType RoomType;
        public DateTime CheckIn;
        public DateTime CheckOut;

        public PaymentInfo PaymentInfo;
        public PaymentStatus PaymentStatus;
        public PaymentAmount PaymentAmount;

        public NewBookingProcessState(List<IEvent> events)
        {
            events.ForEach(e => When((dynamic)e));
        }

        public void When(NewReservation ev)
        {
            Id = ev.Id;
            PaymentInfo = ev.PaymentInfo;
            PaymentStatus = PaymentStatus.Pending;

            RoomType = ev.RoomType;

            CheckIn = ev.CheckIn;
            CheckOut = ev.CheckOut;
        }

        public void When(RoomPriced ev)
        {
            PaymentAmount = ev.PaymentAmount;
        }

        public void When(CardCharged ev)
        {
            PaymentStatus = PaymentStatus.Received;
        }
        
    }
}