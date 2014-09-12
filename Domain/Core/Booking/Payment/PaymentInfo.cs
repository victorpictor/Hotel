using System;

namespace Core.Booking.Payment
{
    public class PaymentInfo
    {
        public Guid Id;

        public string FullName;
        public string CardType;
        public string CardNumber;
        public string CvvNumber;
        public string Expiration;

        public string Email;
    }
}