using Core.Sender;
using Core.Store;
using ProcessManagement.Processes;
using ProcessManagement.Processes.State;

namespace BookingServicesPm.Spec.NewBookingPm
{
    public class MyNewBookingProcess : NewBookingProcess
    {
        public MyNewBookingProcess(IEventStore eventStore, ICommandSerder sender)
            : base(eventStore, sender)
        {
        }

        public NewBookingProcessState State()
        {
            return base.State;
        }

    }
}