using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.HotelRoom
{
    public class Room
    {
        public int Id;

        public RoomType Type;

        public List<BookedOnRange> BookedOn;

        public bool IsAvailable(DateTime from, DateTime to)
        {
            return BookedOn.All(
                b => (b.CheckIn.Date > from && b.CheckIn.Date >= to) ||
                     (b.CheckOut.Date < to && b.CheckOut.Date <= from));
        }
    }
}