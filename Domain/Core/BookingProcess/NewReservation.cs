using System;
using Core.Booking.Payment;
using Core.Booking.TheRoom;
using Core.Markers;

namespace Core.BookingProcess
{
    public class NewReservation : IEvent
    {
        public Guid Id { get; set; }

        public RoomType RoomType;
        public DateTime CheckIn;
        public DateTime CheckOut;
        public PaymentInfo PaymentInfo;
        
    }
}