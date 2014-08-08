using System;
using Inventory.Management;

namespace Inventory.Pricing
{
    public class RoomPrice
    {
        public RoomType RoomType;

        public DateTime StartDate;
        public DateTime EndtDate;

        public double PerNight = 0.0;
    }
}