using Messages.BookingProcess;

namespace ProcessManagement.Processes
{
    public class NewBookingProcess :
        IReceiveMessage<NewReservation>,
        IReceiveMessage<RoomPriced>,
        IReceiveMessage<CardCharged>
    {
        public void Receive(NewReservation message)
        {
            throw new System.NotImplementedException();
        }

        public void Receive(RoomPriced message)
        {
            throw new System.NotImplementedException();
        }

        public void Receive(CardCharged message)
        {
            throw new System.NotImplementedException();
        }

    }
}