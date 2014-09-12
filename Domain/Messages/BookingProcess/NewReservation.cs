using System;
using Core.Booking.Payment;
using Core.Booking.TheRoom;
using Core.Markers;

namespace Core.BookingProcess
{
    public class NewReservation:IMessage
    {
        public Guid Id;

        public RoomType RoomType;
        public DateTime CheckIn;
        public DateTime CheckOut;
        public PaymentInfo PaymentInfo;
    }
}