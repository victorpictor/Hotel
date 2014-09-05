using System;
using Core.TheRoom;

namespace Inventory.Holds
{
    public class SubmittedBookRoomRequest
    {
        public Guid Id;
        public int RoomId;
        public RoomType RoomType;
        public DateTime StartDate;
        public DateTime EndDate;
    }
}