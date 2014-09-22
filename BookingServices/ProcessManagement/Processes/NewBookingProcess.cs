using System;
using Core.Availability;
using Core.BookingProcess;
using Core.Markers;
using Core.Pricing;
using Core.Sender;
using Core.Store;
using Messages.Availability;
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
        private ICommandSerder sender;
       
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

            sender.Send(new ApplyHoldOnRoomAvailability(){Id = message.Id,RoomType = message.RoomType, StartDate = message.CheckIn, EndDate = message.CheckOut});
            sender.Send(new GetRoomPrice() { Id = message.Id, RoomType = message.RoomType, StartDate = message.CheckIn, EndDate = message.CheckOut });
        }

        public void Receive(RoomPriced message)
        {
            Receive(e => State.When((dynamic)e), message);
        }

        public void Receive(AppliedHoldOnRoom message)
        {
            Receive(e => State.When((dynamic)e), message);
        }

        public void Receive(NoRoomsAvailable message)
        {
            Receive(e => State.When((dynamic)e), message);
        }

        public void Receive(CardCharged message)
        {
            Receive(e => State.When((dynamic)e), message);
        }
    }
}