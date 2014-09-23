﻿using System;
using Core.Booking.Payment;
using Core.Markers;

namespace Core.Payments
{
    public class ChargeCard:ICommand
    {
        public Guid Id { get; set; }

        public PaymentInfo PaymentInfo;
        public PaymentAmount PaymentAmount;
    }
}