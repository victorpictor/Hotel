using System;
using Core.BookingProcess;
using Core.Markers;
using Core.Store;
using ProcessManagement.Processes.State;

namespace ProcessManagement.Processes
{
    public class NewBookingProcess :
        IHave<NewBookingProcessState>,
        IReceiveMessage<NewReservation>,
        IReceiveMessage<RoomPriced>,
        IReceiveMessage<CardCharged>
    {

        protected NewBookingProcessState State { get; set; }

        private IEventStore store;

        public NewBookingProcess(IEventStore eventStore)
        {
            this.store = eventStore;
        }

        protected override void Receive(Action<IEvent> action, IEvent @event)
        {
            LoadProcessstate(@event.Id);
            
            action(@event);

            store.AppendToStream(@event.Id,@event);
        }

        private void LoadProcessstate(Guid processId)
        {
            var history = store.LoadStream(processId);
            this.State = new NewBookingProcessState(history);
        }

        public void Receive(NewReservation message)
        {
            Receive(e => State.When((dynamic) e), message);
        }


        public void Receive(RoomPriced message)
        {
            Receive(e => State.When((dynamic)e), message);
        }

        public void Receive(CardCharged message)
        {
            Receive(e => State.When((dynamic)e), message);
        }
    }
}