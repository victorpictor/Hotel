using System;
using Core.Booking.Payment;
using Core.Markers;

namespace Core.BookingProcess
{
    public class RoomPriced:IEvent
    {
        public Guid Id { get; set; }

        public PaymentAmount PaymentAmount { get; set; }
    }
}