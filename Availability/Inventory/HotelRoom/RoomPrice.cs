using System;

namespace Inventory.HotelRoom
{
    public class RoomPrice
    {
        public Guid Id = Guid.NewGuid();

        public RoomType RoomType;

        public DateTime StartDate;
        public DateTime EndtDate;

        public double PerNight = 0.0;
    }
}