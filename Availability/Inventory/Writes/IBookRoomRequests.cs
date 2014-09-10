using Inventory.HotelRoom;

namespace Inventory.Writes
{
    public interface IBookRoomRequests
    {
        void Add(SubmittedBookRoomRequest request);
    }
}