using System.Collections.Generic;
using Core.Markers;

namespace Core.Sender
{
    public class Bus
    {
        private ICommandSerder sender;
        private IEventPublisher publisher;

        public Bus(ICommandSerder sender, IEventPublisher publisher)
        {
            this.sender = sender;
            this.publisher = publisher;
        }

        public void Send(ICommand command)
        {
            sender.Send(command);
        }

        public void Publish(IEvent @event)
        {
            publisher.Publish(@event);
        }

        public void Publish(List<IEvent> @events)
        {
            @events.ForEach(e => publisher.Publish(e));
        }
    }
}