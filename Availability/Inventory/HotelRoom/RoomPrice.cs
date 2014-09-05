using System;
using Core.TheRoom;

namespace Inventory.HotelRoom
{
    public class RoomPrice
    {
        public RoomPrice()
        {}

        public RoomPrice(RoomType roomType, DateTime startDate, DateTime endtDate, double perNight)
        {
            RoomType = roomType;
            StartDate = startDate;
            EndtDate = endtDate;
            PerNight = perNight;
        }


        public Guid Id = Guid.NewGuid();

        public RoomType RoomType;

        public DateTime StartDate;
        public DateTime EndtDate;

        public double PerNight = 0.0;
    }
}