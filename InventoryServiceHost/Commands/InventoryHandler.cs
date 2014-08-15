using Inventory.Holds;
using Messages.Availability;

namespace InventoryServiceHost.Commands
{
    public class InventoryHandler
    {
        private IBookRoomRequests bookRoomRequests;

        public void Handle(AplyHoldOnRoomAvailability c)
        {
            bookRoomRequests.Add(new SubmittedBookRoomRequest());
        }

        public void Handle(MarkRoomBooked c)
        {
        }
    }
}