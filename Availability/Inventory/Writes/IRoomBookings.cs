using System;

namespace Inventory.Writes
{
    public interface IRoomBookings
    {
        void Add(int roomId, DateTime checkIn, DateTime checkOut);
    }
}