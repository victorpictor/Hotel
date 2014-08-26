using System;

namespace Inventory.Holds
{
    public class SubmittedBookRoomRequest
    {
        public int Id;

        public int RoomId;

        public DateTime StartDate;
        public DateTime EndDate;
    }
}