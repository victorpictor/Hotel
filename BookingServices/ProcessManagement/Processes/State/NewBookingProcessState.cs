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
        }

        public void When(NewReservation ev)
        {
        }

        public void When(RoomPriced ev)
        {
        }

        public void When(CardCharged ev)
        {
        }
        
    }
}