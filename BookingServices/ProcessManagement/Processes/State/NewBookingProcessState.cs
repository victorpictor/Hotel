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

        public bool HoldingAvailability;
        public bool RoomPriced;

        public PaymentInfo PaymentInfo;
        public PaymentStatus PaymentStatus;
        public PaymentAmount PaymentAmount;


        public NewBookingProcessState(List<IEvent> events)
        {
            events.ForEach(e => Apply((dynamic)e));
        }

        public void Apply(NewReservation ev)
        {
            Id = ev.Id;
            PaymentInfo = ev.PaymentInfo;
            PaymentStatus = PaymentStatus.Pending;

            RoomType = ev.RoomType;

            CheckIn = ev.CheckIn;
            CheckOut = ev.CheckOut;
        }

        public void Apply(RoomPriced ev)
        {
            PaymentAmount = ev.PaymentAmount;
            RoomPriced = true;
        }

        public void Apply(CardCharged ev)
        {
            PaymentStatus = PaymentStatus.Received;
        }

        public void Apply(AppliedHoldOnRoom ev)
        {
            HoldingAvailability = true;
        }

        public void Apply(ChargeCardFailed ev)
        {
            PaymentStatus = PaymentStatus.Declined;
        }

        
    }
}