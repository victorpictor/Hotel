using Core.BookingProcess;
using ProcessManagement.Processes.State;

namespace ProcessManagement.Processes
{
    public class NewBookingProcess :
        IHave<NewBookingProcessState>,
        IReceiveMessage<NewReservation>,
        IReceiveMessage<RoomPriced>,
        IReceiveMessage<CardCharged>
    {

        public NewBookingProcess()
        {
            //load it from event source
            this.State = new NewBookingProcessState();
        }

        
        protected NewBookingProcessState State { get; set; }

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