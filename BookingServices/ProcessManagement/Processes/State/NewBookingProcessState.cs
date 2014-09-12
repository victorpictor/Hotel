using System;
using Core.Booking.Payment;
using Core.Booking.TheRoom;

namespace ProcessManagement.Processes.State
{
    public class NewBookingProcessState
    {

        public NewBookingProcessState()
        {
        }

        public Guid Id;

        public RoomType RoomType;
        public DateTime CheckIn;
        public DateTime CheckOut;

        public PaymentInfo PaymentInfo;
        public PaymentStatus PaymentStatus;
        public PaymentAmount PaymentAmount;

    }
}