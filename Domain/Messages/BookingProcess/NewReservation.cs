using System;
using Core.Payment;
using Core.TheRoom;
using Messages.Markers;

namespace Messages.BookingProcess
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