using Messages.BookingProcess;

namespace ProcessManagement.Processes
{
    public class NewBookingProcess: IReceiveMessage<NewReservation>
    {
        public void Receive(NewReservation message)
        {
            throw new System.NotImplementedException();
        }



    }
}