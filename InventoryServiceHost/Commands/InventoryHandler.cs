using Inventory.Holds;
using Messages.Availability;

namespace InventoryServiceHost.Commands
{
    public class InventoryHandler
    {
        private IBookRoomRequests bookRoomRequests;

        public void Handle(AplyHoldOnRoomAvailability c)
        {
            //Get a room by type assign to request
            //Add verification if the room is still available
            bookRoomRequests.Add(new SubmittedBookRoomRequest()
                {
                    Id = c.Id,
                    RoomType = c.RoomType,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                });
        }

        public void Handle(MarkRoomBooked c)
        {
        }
    }
}