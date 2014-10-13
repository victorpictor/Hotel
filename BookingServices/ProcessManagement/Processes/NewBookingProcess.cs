using System;
using Core.BookingProcess;
using Core.Markers;
using Core.Payments;
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
        private IEventPublisher publisher;

        public NewBookingProcess(IEventStore eventStore, ICommandSerder sender)
        {
            this.store = eventStore;
            this.sender = sender;
        }

        protected override void Receive(Action<IEvent> action, IEvent @event)
        {
            LoadProcessState(@event.Id);
            
            action(@event);

            store.AppendToStream(@event.Id,@event);
        }

        private void LoadProcessState(Guid processId)
        {
            var history = store.LoadStream(processId);
            this.State = new NewBookingProcessState(history);
        }

        public void Receive(NewReservation message)
        {
            Receive(e => State.Apply((dynamic) e), message);

            sender.Send(new ApplyHoldOnRoomAvailability(){Id = message.Id,RoomType = message.RoomType, StartDate = message.CheckIn, EndDate = message.CheckOut});
            sender.Send(new GetRoomPrice() { Id = message.Id, RoomType = message.RoomType, StartDate = message.CheckIn, EndDate = message.CheckOut });
        }

        public void Receive(RoomPriced message)
        {
            Receive(e => State.Apply((dynamic)e), message);

            if (State.HoldingAvailability)
                sender.Send(new ChargeCard(){Id = message.Id, PaymentInfo = State.PaymentInfo, PaymentAmount = State.PaymentAmount});
        }

        public void Receive(AppliedHoldOnRoom message)
        {
            Receive(e => State.Apply((dynamic)e), message);

            if (State.RoomPriced)
                sender.Send(new ChargeCard() { Id = message.Id, PaymentInfo = State.PaymentInfo, PaymentAmount = State.PaymentAmount });
        }

        public void Receive(NoRoomsAvailable message)
        {
            Receive(e => State.Apply((dynamic)e), message);

            publisher.Publish(message);
        }

        public void Receive(CardCharged message)
        {
            Receive(e => State.Apply((dynamic)e), message);

            publisher.Publish(message);
        }

        public void Receive(ChargeCardFailed message)
        {
            Receive(e => State.Apply((dynamic)e), message);

            publisher.Publish(message);
        }
    }
}